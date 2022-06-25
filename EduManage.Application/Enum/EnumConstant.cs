using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduManage.Application.Enum
{
    /// <summary>
    /// Bộ enum dự án
    /// </summary>
    public enum Bank
    {
        E_BIDV,
        E_ACB
    }

    /// <summary>
    /// Bộ enum loại bảng ký
    /// </summary>
    public enum TypeTemplateSignature
    {
        E_SalaryMonth,
        E_SalaryAdvance
    }

    public enum StatusSign
    {
        E_SUBMIT,
        E_SIGNATURE1,
        E_SIGNATURE2,
        E_SIGNATURE3,
        E_DONE,
        E_REJECT,
    }

    public enum StatusSignDetail
    {
        E_WAITING,
        E_DONE,
        E_REJECT,
    }

    public enum StatusTransfer
    {
        /// <summary>
        /// Đang đợi quá trình ký
        /// </summary>
        E_WAITING,
        /// <summary>
        /// Đang yêu cầu ngân hàng xử lý
        /// </summary>
        E_SUBMIT_BANK,
        /// <summary>
        /// Hủy
        /// </summary>
        E_CANCEL,
        /// <summary>
        /// Chuyền file ngân hàng thất bại
        /// </summary>
        E_POSTFTPFAIL,
    }

    public enum TypeUser
    {
        E_Admin,
        E_User,
    }

    public enum SignatureHistoryEnum
    {
        /// <summary>
        /// Khởi tạo yêu cầu ký bảng lương
        /// </summary>
        E_SUBMIT,
        /// <summary>
        /// Từ chối ký
        /// </summary>
        E_REJECT,
        /// <summary>
        /// Đã ký
        /// </summary>
        E_SIGNED,
        /// <summary>
        /// Đã tải file
        /// </summary>
        E_DOWNLOADFILE,
        /// <summary>
        /// Đã tải file ký
        /// </summary>
        E_DOWNLOADFILERESULT
    }
}
