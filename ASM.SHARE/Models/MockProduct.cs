

using ASM.SHARE.Entities;
using System.Collections.Generic;

namespace ASM.SHARE.Models
{
    public class MockProduct
    {

        private List<Product> products = new()
        {
            new Product
            {
                Name = "Bánh Gà Thần Thánh",
                Price = 70000,
                Address = "11 Ngõ 158 Hồng Mai, P. Bạch Mai, Hai Bà Trưng, Hà Nội",
                Desc = "1 suất 3 chiếc, phomai kéo sợi thơm ngon lun ạ ❤️ Nếu có vấn đề về đơn hàng vui lòng lh 0354.164.127 để được hỗ trợ xử lý, đừng vội đánh giá 1 sao, tội nghiệp quán ạ! Chân thành cảm ơn quí khách!"
                ,
                CreatedDate = System.DateTime.UtcNow,
                ImageUrl = "/uploads/Product01.jpg",
                Quantity = 412,
                CategoryId = 1
            },

            new Product
            {
                Name = "Mì Trộn Indomie",
                Price = 35000,
                Address = "Ngõ 180 Nguyễn Lương Bằng (108 Ngõ 19 Trần Quang Diệu), P. Quang Trung, Đống Đa, Hà Nội",
                Desc = "Giảm 25K khi đặt combo có Coca-Cola. Số lượng ưu đãi có hạn. Áp dụng từ 27/05/2022 - 07/06/2022"
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product02.jpg",
                Quantity = 514,

                CategoryId = 1
            },

            new Product
            {
                Name = "Mì Vịt Quay",
                Price = 150000,
                Address = "103 Hàng Buồm, P. Hàng Buồm, Hoàn Kiếm, Hà Nội",
                Desc = "Nước có thể chọn: Pepsi/Tea+/Sting/7Up/Mirinda"
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product03.jpg",
                Quantity = 75,

                CategoryId = 1
            },
            new Product
            {
                Name = "Cơm Thố Bò + Gà",
                Price = 25000,
                Address = "37 Dương Khuê, P. Mai Dịch, Cầu Giấy, Hà Nội",
                Desc = "Sự kết hợp hài hoà giữa Thịt Bò Cùng Thịt Gà ở Thố này . Sẽ là sự lựa chọn Thông Minh cho quý khách nếu muốn thưởng thức 2 món khác nhau "
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product04.jpg",
                Quantity = 741,

                CategoryId = 1
            },
            new Product
            {
                Name = "Cháo Gia Truyền 37",
                Price = 66000,
                Address = "37 Trần Nhân Tông,  Quận Hai Bà Trưng, Hà Nội",
                Desc = "Nhân tim gan cật các thứ đc làm để ngoài riêng, cháo thì xay vỡ hạt nấu nồi riêng, chắc ko có nước xương vì nồi cháo nhìn trắng tinh ."
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product05.jpg",
                Quantity = 100,

                CategoryId = 1
            },

            new Product
            {
                Name = "Bún Đậu Mắm Tôm",
                Price = 35000,
                Address = "40 Ngõ 460 Khương Đình,  Quận Thanh Xuân, Hà Nội",
                Desc = "Quán dễ tìm và không gian sạch sẽ.Một xuất ăn đủ no.Các bạn chủ quán thân thiện. Điểm trừ : nem hơi nhỏ do chủ ý hay gì thì không biết nhưng ăn cũng rất ngon."
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product06.jpg",
                Quantity = 410,

                CategoryId = 1
            },

            new Product
            {
                Name = "Nước Dừa Trân Châu Dừa Cô Hiền",
                Price = 20000,
                Address = "187/30 Mai Xuân Thưởng, P. 5, Quận 6, TP. HCM",
                Desc = "Không cơm dừa, không topping. Khách muốn thêm topping vui lòng tick vào chọn topping"
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product07.jpg",
                Quantity = 100,

                CategoryId = 2
            },
            new Product
            {
                Name = "The Alley - Trà Sữa Đài Loan",
                Price = 20000,
                Address = "68 Nguyễn Huệ, P. Bến Nghé,  Quận 1, TP. HCM",
                Desc = "điểm trừ khi đặt trên now đó là không đặt được các món độc quyền trên app khác :( trên baemin có trà hojicha đào ngon lắm các bạn ưi"
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product08.jpg",
                Quantity = 200,

                CategoryId = 2
            },

            new Product
            {
                Name = "Đá Bào Milo Dầm",
                Price = 28000,
                Address = "138 Nguyễn Thái Sơn, P. 3,  Quận Gò Vấp, TP. HCM",
                Desc = "Món này hót hòn họt :))))) matcha ở đây ngon nhá, thơm thơm, trân châu dai ngon 👍"
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product09.jpg",
                Quantity = 125,

                CategoryId = 2
            },

            new Product
            {
                Name = "Cà Phê Cốt Dừa & Dừa Dầm",
                Price = 50000,
                Address = "748 Huỳnh Tấn Phát, P. Tân Phú,  Quận 7, TP. HCM",
                Desc = "Ngon tuyệt"
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product10.jpg",
                Quantity = 156,

                CategoryId = 2
            },
            new Product
            {
                Name = "Rau Câu Dừa Phô Mai",
                Price = 10000,
                Address = "Lô A021 CC Huỳnh Văn Chính 1, P. Phú Trung,  Quận Tân Phú, TP. HCM",
                Desc = "Bánh Plan làm dẻo mịn mà ngon lắm. Có kèm theo nước cốt dừa nửa á, béo béo. Ăn dính lắm nha"
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product11.jpg",
                Quantity = 800,

                CategoryId = 2
            },
            new Product
            {
                Name = "Sun Fresh Ice Cream",
                Price = 30000,
                Address = "Hẻm 141 Hai Bà Trưng,  Quận 3, TP. HCM",
                Desc = "em homemade nha rất nhiều vị, theo mình là cũng ngon nhưng tùy vị, vị rhum rất rất ngon còn có những vị lại rất bình thường hoy à"
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product12.jpg",
                Quantity = 45,

                CategoryId = 2
            },
            new Product
            {
                Name = "Bún Riêu Chay",
                Price = 25000,
                Address = "53 Quốc Lộ 13, P. Hiệp Bình Phước,  Tp. Thủ Đức, TP. HCM",
                Desc = "Từ nước dùng cho tới nguyên liệu, thích nhất quán này là vì quán không cố ý làm giả mặn. Nước dùng sử dụng cà chua và tàu hủ dầm nát"
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product13.jpg",
                Quantity = 200,

                CategoryId = 3
            },
            new Product
            {
                Name = "Hủ Tiếu Chay Cây Đề",
                Price = 22000,
                Address = "299 Nguyễn Sơn, P. Phú Thạnh,  Quận Tân Phú, TP. HCM",
                Desc = "Từ nước dùng cho tới nguyên liệu, thích nhất quán này là vì quán không cố ý làm giả mặn. Nước dùng sử dụng cà chua và tàu hủ dầm nát"
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product14.jpg",
                CategoryId = 3
            },

            new Product
            {
                Name = "Hủ Tiếu Chay Cây Đề",
                Price = 22000,
                Address = "299 Nguyễn Sơn, P. Phú Thạnh,  Quận Tân Phú, TP. HCM",
                Desc = "Đặt hàng lần thứ 4 nhưng vẫn không đúng yêu cầu. Dặn cho nhiều hủ tiếu nhưng vẫn để rất ít. Khá nhiều lần nên lần này mới lên đây bình luận"
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product14.jpg",
                CategoryId = 3
            },

            new Product
            {
                Name = "Lẩu Nấm Chay An Nhiên",
                Price = 22000,
                Address = "126 Nguyễn Văn Thủ, P. Đa Kao,  Quận 1, TP. HCM",
                Desc = "ăn lẩu thì bỏ hết rau vào thì cũng dẹp dĩa đi nhưng bạn nhất quyết ko cho. Mặc dù là nguyên cái quán ko có khách nào khác ngoài mình"
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product15.jpg",
                CategoryId = 3
            },

            new Product
            {
                Name = "Cơm Chay Pháp Hạnh",
                Price = 25000,
                Address = "45C Bình Thới,  Quận 11, TP. HCM",
                Desc = "Mình đang ăn chay nên mỗi ngày đều order 2 món về ăn. Cơm khá nhiều, có canh đi kèm. Các món n"
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product16.jpg",
                CategoryId = 3
            },

            new Product
            {
                Name = "Phở Chay Dì Tư",
                Price = 25000,
                Address = "376/42 Nguyễn Đình Chiểu,  Quận 3, TP. HCM",
                Desc = "! Trước hết xin cảm ơn sự ủng hộ của mọi người.Nay vì địa chỉ cũ chủ nhà đã lấy lại nhà nay mẹ mình dời về g"
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product17.jpg",
                CategoryId = 3
            },
            new Product
            {
                Name = "Bánh Mì Chay",
                Price = 20000,
                Address = "256 Ngô Quyền, P. 8,  Quận 10, TP. HCM",
                Desc = "Ngon,giá hợp lý!"
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product18.jpg",
                CategoryId = 3
            },

            new Product
            {
                Name = "Bánh Sầu Riêng",
                Price = 70000,
                Address = "61 Đường Số 7, P. Thạnh Mỹ Lợi,  Quận 2, TP. HCM",
                Desc = "Quán nhiều chi nhánh, Q2 cũng có luôn, đặt biệt bánh ngàn lớp rất ngon"
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product19.jpg",
                CategoryId = 4
            },

            new Product
            {
                Name = "Bánh Biscotti",
                Price = 90000,
                Address = "522/525 Nguyễn Duy, P. 10,  Quận 8, TP. HCM",
                Desc = "Chi nhánh Q8 giảm 25%"
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product20.jpg",
                CategoryId = 4
            },

            new Product
            {
                Name = "Bánh Sandwich Nướng Kẹp Cadé Singapore",
                Price = 75000,
                Address = "28 Phan Phú Tiên, P. 10,  Quận 5, TP. HCM",
                Desc = "Bánh ăn ngon , vị y hệt hồi trước mình ăn qua ở Sing luôn , trà sữa uống thơm , giá okay nè"
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product21.jpg",
                CategoryId = 4
            },

            new Product
            {
                Name = "Vina Chuối",
                Price = 45000,
                Address = "1 Bạch Vân, P. 5,  Quận 5, TP. HCM",
                Desc = "Thèm chuối chiên quá mà ít store gần nhà nên nhờ ck đi làm về ghé mua,"
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product22.jpg",
                CategoryId = 4
            },

            new Product
            {
                Name = "Bánh Flan Caramen",
                Price = 10000,
                Address = "10 Cô Giang, P. 2,  Quận Phú Nhuận, TP. HCM",
                Desc = "Mình gọi bánh plan truyền thống, trà xanh và matcha. Chất của 3 cái y như nhau k béo nó cứ bột bột kiểu"
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product23.jpg",
                CategoryId = 4
            },

            new Product
            {
                Name = "Bánh Kem Pháp",
                Price = 95000,
                Address = "190/6 Nguyễn Gia Trí (Đường D2), P. 25,  Quận Bình Thạnh, TP. HCM",
                Desc = "Bánh ăn ngon nhưng người bán hàng chưa khi nào mình hài lòng luôn á"
                ,
                CreatedDate = System.DateTime.UtcNow,

                ImageUrl = "/uploads/Product24.jpg",
                CategoryId = 4
            },
        };

        public List<Product> GetProducts()
        {
            return products;
        }
    }
}