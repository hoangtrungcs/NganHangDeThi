using Common;
using Controller.Services;
using Model.POCO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace NganHangDeThi.Helpers {
    public class ExportHelpers {
        private const string SUBJECT_NAME = "SUBJECT_NAME";
        private const string SUBJECT_NO = "SUBJECT_NO";
        private const string SUBJECT_DELECTED = "IS_DELETED";
        private ExportHelpers() { }

        public static void ExportQuestion(string fileName, IEnumerable<Question> questions) {
            XDocument questionDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            // Add root node
            questionDoc.Add(new XElement("QB"));
            var groups = questions
                .GroupBy(x => x.Subject.SubjectId)
                .ToDictionary(x => x.Key, x => x.ToList());
            List<XElement> subjectList = new List<XElement>();
            foreach (var grouping in groups) {
                Subject subject = grouping.Value.FirstOrDefault().Subject;
                List<XElement> questionList = new List<XElement>();
                foreach (Question question in grouping.Value) {
                    List<XElement> answerList = new List<XElement>();
                    foreach (var answer in question.Answers) {
                        XElement answerElement = new XElement("A",
                                                    new XAttribute("ia", answer.IsAnswer),
                                                    new XElement("C", answer.Content));
                        answerList.Add(answerElement);
                    }
                    XElement questionElement = new XElement("Q", new XAttribute("l", question.Level),
                                                                 new XAttribute("tp", question.Type),
                                                                 new XAttribute("tm", question.Time),
                                                                 new XAttribute("p", question.Purpose),
                                                                 new XAttribute("g", question.QuestionGuid.ToString()),
                                                                 new XAttribute("ra", question.IsAnswerRandom.GetValueOrDefault(false)),
                                                    new XElement("C", question.Content));
                    questionElement.Add(answerList);
                    questionList.Add(questionElement);
                }
                XElement subjectElement = new XElement("S",
                                            new XElement("Sno", subject.SubjectNo),
                                            new XElement("Snm", subject.Name),
                                            new XElement("Sg", subject.SubjectGuid.ToString())
                                            );
                subjectElement.Add(questionList);
                subjectList.Add(subjectElement);
            }
            questionDoc.Element("QB").Add(subjectList);
            questionDoc.Save(fileName);
        }
        public static IList<Subject> ImportQuestion(string filePath) {
            try {
                var subjects = new List<Subject>();
                if (File.Exists(filePath)) {
                    XDocument subjectDoc = XDocument.Load(filePath);
                    // Get subject list
                    IEnumerable<XElement> subjectList = subjectDoc.Descendants("S");
                    foreach (XElement subjectElement in subjectList) {
                        var subject = new Subject();
                        subject.SubjectNo = subjectElement.Element("Sno").Value;
                        subject.Name = subjectElement.Element("Snm").Value;
                        subject.SubjectGuid = new Guid(subjectElement.Element("Sg").Value);
                        // Get quetions list
                        IEnumerable<XElement> questionList = subjectElement.Elements("Q");
                        foreach (XElement questionElement in questionList) {
                            var question = new Question();
                            question.CreatedBy = UserService.CurrentUser.CurrentUser.Username;
                            question.CreatedDate = DateTime.Now;
                            question.UpdatedBy = UserService.CurrentUser.CurrentUser.Username;
                            question.UpdatedDate = DateTime.Now;
                            question.Level = Convert.ToInt32(questionElement.Attribute("l").Value);
                            question.Type = Convert.ToInt32(questionElement.Attribute("tp").Value);
                            question.Time  = Convert.ToDouble(questionElement.Attribute("tm").Value);
                       
                            question.Purpose = Convert.ToInt32(questionElement.Attribute("p").Value);
                            question.Content = questionElement.Element("C").Value;
                            question.QuestionGuid = new Guid(questionElement.Attribute("g").Value);
                            question.IsAnswerRandom = Convert.ToBoolean(questionElement.Attribute("ra").Value);
                            //  Get answer list
                            IEnumerable<XElement> answerList = questionElement.Elements("A");
                            foreach (XElement answerElement in answerList) {
                                var answer = new Answer();
                                answer.Content = answerElement.Element("C").Value;
                                question.Answers.Add(answer);
                                if (Convert.ToBoolean(answerElement.Attribute("ia").Value)) {
                                    answer.IsAnswer = true;
                                } else {
                                    answer.IsAnswer = false;
                                }
                            }
                            subject.Questions.Add(question);
                        }
                        subjects.Add(subject);
                    }
                    return subjects;
                }
            } catch {
                throw new Exception("Cannot Import");
            }
            return null;
        }
    }
}
