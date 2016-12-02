using System.Collections.Generic;
using System.Linq;
using Common;
using Model.POCO;

namespace Model {
    public class UserModel {
        private Teacher m_user;
        private IList<UserSubjectRight> m_rights;

        public UserModel(Teacher teacher, IList<UserSubjectRight> rights) {
            m_user = teacher;
            m_rights = rights;
        }
        public bool HasRight(int subjectId, RightType type) {
            return m_rights != null && m_rights.Count(x => x.FK_SubjectId == subjectId && (x.Right & (int)type) == (int)type) > 0;
        }
        public Teacher CurrentUser {
            get { return m_user; }
        }
        public List<int> GetAllAvailableSubjectIds() {
            return m_rights.Where(x => x.Right > 0).Select(x => x.FK_SubjectId).ToList();
        }
        public bool HasRole(UserRole role) {
            return (m_user != null && (m_user.Roles & (int)role) == (int)role);
        }
    }
}
