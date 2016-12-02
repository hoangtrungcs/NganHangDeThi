using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NganHangDeThi.Helpers;
namespace Common {
    public class NumberQuestionNotEnoughException : Exception{
        public QuestionLevel Level { get; set; }
        public PurposeOverview QuestionPurpose { get; set; }
        public int NumberInDb { get; set; }
        public string ErrorMsg { get; private set; }
        public NumberQuestionNotEnoughException(QuestionLevel level, PurposeOverview overview, int number) {
            Level = level;
            QuestionPurpose = overview;
            NumberInDb = number;
            ErrorMsg =
                string.Format(
                    "Số lượng câu hỏi mức độ {0} cho mục đích {1} hiện có là {2}. Bạn vui lòng kiểm tra lại số lượng bạn cần!",
                    EnumHelpers.GetLevelDisplayText((int)level), EnumHelpers.GetPurposeDisplayText((int) overview), number);
        }
    }
}
