namespace Common {
    public enum FormAction : int {
        /// <summary>
        /// None
        /// </summary>
        None = 0,
        /// <summary>
        /// Add entity
        /// </summary>
        Add = 1,
        /// <summary>
        /// Edit current entity
        /// </summary>
        Edit = 2,
        /// <summary>
        /// Save entity
        /// </summary>
        Save = 3,
        /// <summary>
        /// Delete current entity
        /// </summary>
        Delete = 4,
        /// <summary>
        /// Cancel modifies
        /// </summary>
        Cancel = 5
    }
    public enum QuestionType : int {
        Custom = 0,
        Choice = 1
    }

    public enum PurposeOverview : int {
        Overview = 0,
        Review = 1,
        Test = 2,
        Competition = 3,
        Total = 4
    }
    public enum UserRole : int {
        Administrator = 1,
        Teacher = 2,
        Student = 4
    }
    public enum RightType : int {
        None = 0,
        List = 1,
        Create = 2,
        Edit = 4,
        Delete = 8,
        ListTest = 16,
        CreateTest = 32,
        EditTest = 64,
        DeleteTest = 128
    }

    public enum QuestionLevel : int {
        Easy = 0,
        Normal = 1,
        Hard = 2
    }
}
