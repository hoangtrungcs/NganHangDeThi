using System.Xml;
using Controller.Services;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Model.POCO;
using Telerik.WinControls.UI;

namespace StudentTesting {
    public partial class MainForm : RadForm {
        private TestsService m_testService;
        private QuestionsService m_questionService;
        private Test m_currentTest;
        private int m_time;
        private bool hasSave = false;
        private int m_currentQuestionIndex;
        private List<Question> m_questions;
        private Dictionary<long, long> m_studentSelections;
        private DateTime m_startTime;
        public MainForm() {
            InitializeComponent();

        }
        public MainForm(int subjectId)
            : this() {
            //InitializeComponent();
            NganHangEntities db = new NganHangEntities();
            m_testService = new TestsService(db);
            m_questionService = new QuestionsService(db);
            m_currentTest = m_testService.GetTestForStudent(StudentsService.CurrentStudent.StudentId, subjectId);
            m_time = m_currentTest.Time * 60; // second
            RandomQuestion();
            m_studentSelections = new Dictionary<long, long>(m_questions.Count);

            m_lblStudentName.Text += " " + StudentsService.CurrentStudent.UserName;
            m_lblStudentNo.Text += " " + StudentsService.CurrentStudent.StudentNo;
            m_lblDethi.Text = " " + m_currentTest.Name;
            m_lblNgayThi.Text += m_currentTest.TestDate.ToString(" dd/MM/yyyy");
            m_lblTime.Text += m_currentTest.Time + " phut";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            LoadQuestion();
        }

        private void RandomQuestion() {
            m_questions = m_questionService.GetAllQuestionByTest(m_currentTest.TestId);
            var max = 200;
            Random ran = new Random();
            for (int i = 0; i < max; i++) {
                int index = ran.Next(m_questions.Count - 1);
                var item = m_questions[i % m_questions.Count];
                m_questions[i % m_questions.Count] = m_questions[index];
                m_questions[index] = item;
            }
            XmlDocument doc = new XmlDocument();
            XmlElement el = (XmlElement)doc.AppendChild(doc.CreateElement("TestDetail"));
            int count = 1;
            foreach (Question question in m_questions) {
                var child = doc.CreateElement("Q");
                child.SetAttribute("qOrder", count.ToString());
                child.SetAttribute("qId", question.QuestionId.ToString());
                el.AppendChild(child);
                count++;
            }
            var structure = doc.OuterXml;

            m_testService.SaveStudentTestStructure(StudentsService.CurrentStudent.StudentId, m_currentTest.TestId, structure);
            timer1.Start();
            m_startTime = DateTime.Now;
        }

        private void OnFinished(object sender, EventArgs e) {
            if (
                MessageBox.Show("Ban co muon hoan tat bai thi?", "Confirmation", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information) == DialogResult.Yes) {
                Finish();
            }
        }

        private void Finish() {
            if (!hasSave) {
                RemindStudentSelection();
                int correctNo =
                    m_questions.Count(
                        x =>
                        m_studentSelections.ContainsKey(x.QuestionId) && x.AnswerId == m_studentSelections[x.QuestionId]);


                int incorrectNo =
                    m_questions.Count(
                        x =>
                        m_studentSelections.ContainsKey(x.QuestionId) && x.AnswerId != m_studentSelections[x.QuestionId]);

                int doNotWork = m_questions.Count - correctNo - incorrectNo;
                List<StudentTestDetail> lstDetail = new List<StudentTestDetail>(m_questions.Count);
                foreach (Question question in m_questions) {
                    long answer = 0;
                    if (m_studentSelections.ContainsKey(question.QuestionId)) {
                        answer = m_studentSelections[question.QuestionId];
                    }
                    lstDetail.Add(new StudentTestDetail() {
                        FK_AnserId = answer,
                        FK_TestId = m_currentTest.TestId,
                        FK_StudentId = StudentsService.CurrentStudent.StudentId,
                        FK_QuestionId = question.QuestionId
                    });
                }
                int usedTime = Convert.ToInt32(DateTime.Now.Subtract(m_startTime).TotalSeconds);
                m_testService.SaveStudentTestDetail(lstDetail);
                m_testService.SaveStudentTest(StudentsService.CurrentStudent.StudentId,
                    m_currentTest.TestId, correctNo, correctNo, incorrectNo, doNotWork, usedTime);


                ResultForm form = new ResultForm();
                form.SetValue(m_currentTest.TestNo, usedTime, correctNo, incorrectNo, doNotWork);
                this.Hide();
                form.ShowDialog();
                hasSave = true;
                this.Close();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Closing" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs" /> that contains the event data.</param>
        protected override void OnClosing(CancelEventArgs e) {
            if (!hasSave) {
                if (
                    MessageBox.Show("Ban muon hoan tat bai thi dung khong?", "Confirmation", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Information) == DialogResult.Yes) {
                    Finish();
                    base.OnClosing(e);
                } else {
                    e.Cancel = true;
                }
            }

        }
        private void timer1_Tick(object sender, EventArgs e) {
            m_time -= 1;

            m_lblMinutes.Text = "" + (m_time / 60) + " phut " + m_time % 60 + " giay";

            if (m_time <= 0) {
                MessageBox.Show("Het gio thi!", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                timer1.Stop();
                Finish();
            }
        }

        private void radButton2_Click(object sender, EventArgs e) {
            RemindStudentSelection();
            m_currentQuestionIndex--;
            if (m_currentQuestionIndex <= 0) {
                radButton2.Enabled = false;
            }
            radButton1.Enabled = true;
            LoadQuestion();

        }

        private void UpdateButtonStatus() {
            radButton2.Enabled = m_currentQuestionIndex > 0;
            radButton1.Enabled = m_currentQuestionIndex < m_questions.Count - 1;
        }
        private void radButton1_Click(object sender, EventArgs e) {
            RemindStudentSelection();
            m_currentQuestionIndex++;
            if (m_currentQuestionIndex >= m_questions.Count - 1) {
                radButton1.Enabled = false;
            }
            radButton2.Enabled = true;
            LoadQuestion();

        }

        private void RemindStudentSelection() {
            long answer = 0;
            if (m_rbA.IsChecked) {
                answer = (long)m_rbA.Tag;
            }
            if (m_rbB.IsChecked) {
                answer = (long)m_rbB.Tag;
            }
            if (m_rbC.IsChecked) {
                answer = (long)m_rbC.Tag;
            }
            if (m_rbD.IsChecked) {
                answer = (long)m_rbD.Tag;
            }

            Question currentQ = m_questions[m_currentQuestionIndex];
            if (!m_studentSelections.ContainsKey(currentQ.QuestionId)) {
                m_studentSelections.Add(currentQ.QuestionId, answer);
            } else {
                m_studentSelections[currentQ.QuestionId] = answer;
            }

        }

        private bool isUpdated = false;

        private void LoadQuestion() {
            radLabel5.Text = (m_currentQuestionIndex + 1) + "";
            Question currentQuestion = m_questions[m_currentQuestionIndex];
            m_txtContent.Text = currentQuestion.Content;

            m_rbA.IsChecked = false;
            m_rbB.IsChecked = false;
            m_rbC.IsChecked = false;
            m_rbD.IsChecked = false;

            List<Answer> answers = currentQuestion.Answers.OrderBy(x => x.AnswerId).Take(4).ToList();
            m_rbA.Tag = answers[0].AnswerId;
            m_rbA.Text = answers[0].Content;

            m_rbB.Tag = answers[1].AnswerId;
            m_rbB.Text = answers[1].Content;

            m_rbC.Tag = answers[2].AnswerId;
            m_rbC.Text = answers[2].Content;

            m_rbD.Tag = answers[3].AnswerId;
            m_rbD.Text = answers[3].Content;

            if (m_studentSelections.ContainsKey(currentQuestion.QuestionId) && m_studentSelections[currentQuestion.QuestionId] > 0) {
                long selectedAnswer = m_studentSelections[currentQuestion.QuestionId];
                if (selectedAnswer == answers[0].AnswerId) {
                    m_rbA.IsChecked = true;
                }
                if (selectedAnswer == answers[1].AnswerId) {
                    m_rbB.IsChecked = true;
                }
                if (selectedAnswer == answers[2].AnswerId) {
                    m_rbC.IsChecked = true;
                }
                if (selectedAnswer == answers[3].AnswerId) {
                    m_rbD.IsChecked = true;
                }
            }
            RefreshGrid();
        }

        private void RefreshGrid() {
            if (!isUpdated) {
                isUpdated = true;
                int no = 1;
                var sources = m_questions.Select(x => new SelectionQuestionModel {
                    IsChecked = m_studentSelections.ContainsKey(x.QuestionId) && m_studentSelections[x.QuestionId] > 0,
                    QuestionNo = no++,
                    Content = x.Content
                }).ToList();
                radGridView1.DataSource = null;
                radGridView1.DataSource = sources;
                radGridView1.Rows[m_currentQuestionIndex].IsSelected = true;
                isUpdated = false;
            }
        }

        private void radGridView1_SelectionChanged(object sender, EventArgs e) {
            if (!isUpdated) {
                isUpdated = true;
                var selectedItem = radGridView1.SelectedRows.FirstOrDefault().DataBoundItem as SelectionQuestionModel;
                if (selectedItem != null) {
                    RemindStudentSelection();
                    m_currentQuestionIndex = selectedItem.QuestionNo - 1;
                    UpdateButtonStatus();
                    LoadQuestion();
                }
                isUpdated = false;
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class SelectionQuestionModel {
        public bool IsChecked { get; set; }
        public int QuestionNo { get; set; }
        public string Content { get; set; }
    }
}
