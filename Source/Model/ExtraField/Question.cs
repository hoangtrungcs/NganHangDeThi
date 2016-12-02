using System;
using System.Collections.ObjectModel;
using System.Linq;
using NganHangDeThi.Helpers;
using Common;

namespace Model.POCO
{
    public partial class Question
    {

        private Answer m_answerA;
        private Answer m_answerB;
        private Answer m_answerC;
        private Answer m_answerD;
        public string GroupDisplay { get; set; }
        //To use for check list is use
        public bool IsRemove { get; set; }
        public string LevelDisplay
        {
            get { return EnumHelpers.GetLevelDisplayText(Level); }
        }
        public string PurposeDisplay
        {
            get { return EnumHelpers.GetPurposeDisplayText(Purpose); }
        }
        public Answer AnswerA
        {
            get
            {
                if (m_answerA == null)
                {
                    m_answerA = Answers.ElementAt(0);
                    m_answerA.PropertyChanged += m_answerA_PropertyChanged;
                }
                return m_answerA;
            }
        }

        void m_answerA_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender == AnswerA)
            {
                NotifyAnswerChanged("AnswerA");
            }
            else if (sender == AnswerB)
            {
                NotifyAnswerChanged("AnswerB");
            }
            else if (sender == AnswerC)
            {
                NotifyAnswerChanged("AnswerC");
            }
            else if (sender == AnswerD)
            {
                NotifyAnswerChanged("AnswerD");
            }

        }
        public Answer AnswerB
        {
            get
            {
                if (m_answerB == null)
                {
                    if (Type == (int)QuestionType.Choice)
                    {
                        m_answerB = Answers.ElementAt(1);
                        m_answerB.PropertyChanged += m_answerA_PropertyChanged;
                    }
                }
                return m_answerB;
            }
        }
        public Answer AnswerC
        {
            get
            {
                if (m_answerC == null)
                {
                    if (Type == (int)QuestionType.Choice)
                    {
                        m_answerC = Answers.ElementAt(2);
                        m_answerC.PropertyChanged += m_answerA_PropertyChanged;
                    }
                }
                return m_answerC;
            }
        }
        public Answer AnswerD
        {
            get
            {
                if (m_answerD == null)
                {
                    if (Type == (int)QuestionType.Choice)
                    {
                        m_answerD = Answers.ElementAt(3);
                        m_answerD.PropertyChanged += m_answerA_PropertyChanged;
                    }
                }
                return m_answerD;
            }
        }
        private void NotifyAnswerChanged(string name)
        {
            this.HasChanged = true;
            NotifyPropertyChanged(name);
        }

        public bool Checked { get; set; }

        /// <summary>
        /// Content apply for grid in question form that display data with out image.
        /// </summary>
        public string ContentWithoutImage
        {
            get
            {
                if (string.IsNullOrEmpty(Content))
                    return string.Empty;
                return Common.RtfHelpers.ConvertRtfToText(Content);
            }
        }

    }
}
