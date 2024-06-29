
using System.Security.Cryptography;
using System.Text;

namespace MPVI_Warehouse.Util
{
    public class SD
    {

        public enum Role
        {
            Admin, 
            Staff,
            Cust
        }

        public enum DiscountCodeStatus
        {
            Avai,
            Deleted
        }

        public enum NoticeStatus
        {
            New, 
            Seen,
            Deleted
        }

        public enum OrderStatus
        {
            Pending, 
            PaySucess,
            Received, 
            Cancel,
            Deleted
        }

        public enum ProductStatus
        {
            Available,
            Deleted
        }
        

        public static string ComputeSha256Hash(string rawData)
        {
            // Tạo SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Chuyển đổi chuỗi đầu vào thành mảng byte và tính toán hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Chuyển đổi mảng byte thành chuỗi hex
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }




    }
}
