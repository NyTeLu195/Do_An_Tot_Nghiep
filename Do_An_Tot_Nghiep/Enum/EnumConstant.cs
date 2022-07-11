using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Tot_Nghiep.Enum
{
    /// <summary>
    /// Bộ enum môn học
    /// </summary>
    public enum Subject
    {
        E_MATH,
        E_ENGLISH,
        E_LITERATURE,
        E_PHYSICS,
        E_CHEMISTRY,
        E_BIOLOGY,
        E_HISTORY,
        E_GEOGRAPHY,
        E_CIVIC_EDUCATION,
        E_PHYSICAL_EDUCATION,
        E_INFORMATICS,
        E_TECHNOLOGY

    }

    /// <summary>
    /// Bộ enum Thứ trong tuần
    /// </summary>
    public enum Weekdays
    {
        E_Monday,
        E_Tuesday,
        E_Wednesday,
        E_Thursday,
        E_Friday,
        E_Saturday,
        E_Sunday,
    }
    /// <summary>
    /// Bộ enum Phân quyền
    /// </summary>
    public enum UserRole
    {
        E_ADMIN,
        E_MANAGER,
        E_TEACHER,
        E_HOMEROOMTEACHER,
        E_CLASSMASTER,
        E_STUDENT,
    }


}
