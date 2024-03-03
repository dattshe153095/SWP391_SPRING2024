using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Library
{
    public static class StatusEnum
    {
        public const string DANG_XU_LI = "đang xử lí";
        public const string DANG_CHO_XAC_NHAN = "đang chờ xác nhận";
        public const string XAC_NHAN_THANH_CONG = "xác nhận thành công";
        public const string HOAN_THANH = "hoàn thành";
        public const string XAC_NHAN_THAT_BAI = "xác nhận thất bại";
    }

    public static class StateEnum
    {
        public const string THANH_CONG = "thành công";
        public const string THAT_BAI= "thất bại";
        public const string DANG_XU_LI= "đang xử lí";
    }

    public static class IntermediateOrderEnum
    {
        public const string MOI_TAO = "mới tạo";
        public const string SAN_SANG_GIAO_DICH = "sẵn sàng giao dịch";
        public const string HUY = "hủy";
        public const string BEN_MUA_KIEM_TRA_HANG = "bên mua kiểm tra hàng";
        public const string HOAN_THANH = "hoàn thành";
        public const string BEN_MUA_KHIEU_NAI = "bên mua khiếu nại";
        public const string BEN_BAN_DANH_DAU_KHIEU_NAI = "bên bán đánh dấu khiếu nại";
        public const string YEU_CAU_QUAN_TRI = "yêu cầu quản trị";
        public const string CHO_BEN_MUA_XAC_NHAN = "chờ bên mua xác nhận";
    }
}
