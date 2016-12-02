using System.Collections.Generic;
using Common;
using System.Linq;

namespace NganHangDeThi.Helpers {
    public static class EnumHelpers {
        private static List<EnumDisplay> s_levels;
        private static List<EnumDisplay> s_purposes;
        public static List<EnumDisplay> GetAllQuestionLevels() {
            if (s_levels == null) {
                InitLevelList();
            }

            return s_levels;
        }

        private static void InitLevelList() {
            s_levels = new List<EnumDisplay> {
                new EnumDisplay("Dễ", (int) QuestionLevel.Easy),
                new EnumDisplay("Trung bình", (int) QuestionLevel.Normal),
                new EnumDisplay("Khó", (int) QuestionLevel.Hard)
            };
        }

        public static List<EnumDisplay> GetAllQuestionPurpose() {
            if (s_purposes == null) {
                InitPurpose();
            }

            return s_purposes;
        }

        private static void InitPurpose() {
            s_purposes = new List<EnumDisplay>() {
                new EnumDisplay("Tất cả", (int) PurposeOverview.Total),
                new EnumDisplay("Ôn tập", (int) PurposeOverview.Overview),
                new EnumDisplay("Đánh giá", (int) PurposeOverview.Review),
                new EnumDisplay("Kiểm tra", (int) PurposeOverview.Test),
                new EnumDisplay("Thi tuyển", (int) PurposeOverview.Competition)
            };
        }

        public static string GetLevelDisplayText(int value) {
            if (s_levels == null) {
                InitLevelList();
            }
            return s_levels.FirstOrDefault(x => x.Value == value).DisplayText;
        }
        public static string GetPurposeDisplayText(int value) {
            if (s_purposes == null) {
                InitPurpose();
            }
            return s_purposes.FirstOrDefault(x => x.Value == value).DisplayText;
        }
    }
}
