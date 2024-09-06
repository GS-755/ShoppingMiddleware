# ShoppingMiddleware

<details lose="" align="left">
  <summary>  
  # Update: View template css Free by Material UI 
  </summary>
FE:
  <br>
<p align="center">
  <img src="https://github.com/user-attachments/assets/a45f5060-c34b-4d6e-99da-7215de6787f7" width="600"/>
</p>

<p align="center">
  <img src="https://github.com/user-attachments/assets/d6a4a8e2-8939-4ddf-84c6-c2947aa9b657" width="600"/>
</p>

<p align="center">
  <img src="https://github.com/user-attachments/assets/1e54747a-95ff-4790-b013-7ca0e40800e8" width="600"/>
</p>
  <br>
BE: Update views
  <br>
  <p align="center">

update: HomeController - Action Index:
```C#
        public ActionResult Index()
        {
            TrangThaiDonHang trangThaiDon = new TrangThaiDonHang();

            int totalSales = db.DonDatHang
                .Where(s => s.TrangThai == trangThaiDon.DaGiaoHang)
                .Count();

            int totalProduct = db.SanPham
                .Count();

            int totalCustomers = db.NguoiDung
                .Count();

            float totalRevenue = db.DonDatHang
                .Select(r => r.TongTien)
                .Sum();

            var transacstions = new TotalTransactions()
            {
                totalSales = totalSales,
                totalCustomers = totalCustomers,
                totalProduct = totalProduct,
                totalRevenue = totalRevenue,
            };
            return View(transacstions);
        }
```

Add: HomeCotroller - Action Config_StatusOrder_Demo
```c#
  [HttpGet]
        // xử lý trạng thái đơn hàng =>  params (
        // nameid: item của tên Kho cục `Departmentwarehouses`,
        // status: trang thái đơn hàng `TrangThaiDonHang.<Status muốn lấy>`
        // )
        public ActionResult Config_StatusOrder_Demo(int nameid, string status)
        {
            // Get: trạng thái đơn hàng
            TrangThaiDonHang trangThai = new TrangThaiDonHang();

            // Get: tên Kho Cục
            //Departmentwarehouses departmentwarehouses = new Departmentwarehouses();
            string nameDW = new Departmentwarehouses().NameDepartmentwarehouses[nameid];

            // nếu trạng thái = đến kho => trangThai.DenKhoCuc + tên kho cục
            DonDatHang donDatHang;
            if (status == trangThai.DenKhoCuc)
            {
                donDatHang = new DonDatHang()
                {
                    TrangThai = trangThai.DenKhoCuc + nameDW,
                };
            }
            else
            {
                donDatHang = new DonDatHang()
                {
                    TrangThai = status,
                };
            }
            return View();
        }

```

Add: Model DonDatHang, FlutterServiceDTO - class: TrangThaiDonHang, Departmentwarehouses, TotalTransactions.
 
```c#
/*********************************************************** DonDatHang Model ***********************************************************/
    public class TrangThaiDonHang
    {
        public string DaGiaoHang = "Đã giao";
        public string DangXuLy = "Đang xử lý";
        public string DangVanChuyen = "Đang vận Chuyển";
        public string ChoDongGoi = "Chờ Đóng gói";
        public string ChoLayHang = "Chờ lấy hàng";
        public string DangNhapCanh = "Đang nhập cảnh";
        public string DangXuatCang = "Đang xuất cảnh";
        public string DenKhoCuc = "Đến Kho cục ";


    }

    public class Departmentwarehouses
    {
        public string[] NameDepartmentwarehouses;
        public Departmentwarehouses()
        {
            string[] NameDepartmentwarehouses = new string[] {
                "Soc Xuân Thới Thượng Hốc Môn",
                "Soc Hà Nam HCM",
                "Tra vinh",
                "Nam Từ Liêm Hà Nội"
            };
            this.NameDepartmentwarehouses = NameDepartmentwarehouses;
        }
    }

/*********************************************************** Flutter Service DTO Model ***********************************************************/

        public class TotalTransactions
        {
            // Growth:
            public int totalSales { get; set; }
            public int totalCustomers { get; set; }
            public int totalProduct { get; set; }
            public float totalRevenue { get; set; }

        }

```


</p>


---

</details> 

---

<details lose="" align="left">
  <summary>  
  # Update: page user acount 
  </summary>
   
  <img src="https://github.com/user-attachments/assets/1915805c-6cd4-47bf-9e86-b24cf07ac353" width="600"/>

  Load user table:
  
  ```C#
        [HttpGet]
        public ActionResult UsersTable(string roleID)
        {
            if(roleID == "Defaul")
            {
                var userList = db.NguoiDung.ToList();
                return PartialView("NguoiDung", userList);
            }

            IQueryable<NguoiDung> usersQuery = db.NguoiDung;

            if (!string.IsNullOrEmpty(roleID) && int.TryParse(roleID, out int parsedRoleID))
            {
                usersQuery = usersQuery.Where(u => u.IDQuyen == parsedRoleID);
            }

            var users = usersQuery.ToList();
            return PartialView("NguoiDung", users);
        }
  ```

</details>

---

<details open="" align="left">
  <summary>  
  # Update: Update Create user validations.
  </summary>

<p align="center">
  <img src="https://github.com/user-attachments/assets/cc4263a3-d1dc-447d-95e9-deca0a9fb4d5" width="200"/>
</p>

<p align="center">
  <img src="https://github.com/user-attachments/assets/a2ab211c-38a7-4836-b6a5-b5e6969a7c29" width="600"/>
</p>

Update: Model RegexValues  
```C#

    public class RegexValues
    {
        /* *************************** Documents ***************************
         * 
         * Todo: 
         *       + Cln All message Regex before check regex.
         *       + Set isValid is flase when create new Method validate.
         *       + Add new message when Regex `flase`.
         * 
         * *************************** Documents *************************** */


        // Setup:
        public List<string> messages = new List<string>();
        private bool isValid;
        
        public bool IsStrongPassword(string password)
        {
            // setup:
            messages.Clear();
            isValid = false;

            /* Check if the password is empty */
            if (string.IsNullOrEmpty(password))
            {
                messages.Add("Password is empty.");
                return false;
            }

            /* Check password length */
            if (password.Length < 6 || password.Length > 10)
                messages.Add("Password must be longer than 6 and shorter than 10 characters.");
            /* Check for spaces */
            if (password.Contains(" "))
                messages.Add("Password should not contain spaces.");
            // Check if the password contains at least one uppercase letter
            if (!password.Any(char.IsUpper))
                messages.Add("Password must have at least one uppercase letter.");
            // Check if the password contains at least one lowercase letter
            if (!password.Any(char.IsLower))
                messages.Add("Password must have at least one lowercase letter.");
            // Check if the password contains at least one digit
            if (!password.Any(char.IsDigit))
                messages.Add("Password must have at least one digit.");
            // Check if the password contains at least one special character
            if (!password.Any(c => !char.IsLetterOrDigit(c)))
                messages.Add("Password must have at least one special character.");
            
            if( messages.Count <= 0)
                isValid = true;

            return isValid;
        }

        public bool PhoneNumberValid(string phoneNumber)
        {
            // setup:
            messages.Clear();
            isValid = false;

            // Check if phone number is empty.
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                messages.Add("Please input the phone number.");
                return false;
            }
            // Phone number must be exactly 10 digits.
            if (phoneNumber.Length != 10 || !phoneNumber.All(char.IsDigit))
            {
                messages.Add("Phone number must be exactly 10 digits and contain only numbers.");
            }
            // Check if phone number contains at least one character (this check is redundant if above is valid).
            if (!phoneNumber.Any(char.IsDigit))
            {
                messages.Add("Phone number must contain at least one numeric character.");
            }

            // If there are no messages, the phone number is valid.
            if (messages.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    
        public bool UserNameIsValid(string userName)
        {
            // setup:
            messages.Clear();
            isValid = false;

            /* User name not empty */
            if (userName.IsEmpty())
            {
                messages.Add("User name is empty.");
                return false;
            }

            /* User name length validations */
            if (userName.Length <= 2 || userName.Length >= 10) 
                messages.Add("User name short than 3 and long than 10 charaters.");
            /* Check for spaces */
            if (userName.Contains(" "))
                messages.Add("User name should not contain spaces.");
            // User name is valid:
            if(messages.Count <= 0)
            isValid = true;

            return isValid;
        }
    
    }
```
Update: NguoiDungsController - Action Create

```C#
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDND,TenND,Ho_TenDem,Email,GioiTinh,SDT,Tuoi,MatKhau,TenDangNhap,IDQuyen")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                try
                {
                        Code ...

                    // if Account is not exist => check Regex values:
                    else
                    {
                        /* ************************ Documents ************************
                            
                        RegexValues:
                            => messages: List[string] show message invalid values.
                            => functions: 
                                 + UserNameIsValid(string)  => bool
                                 + IsStrongPassword(string) => bool
                                 + PhoneNumberValid(string) => bool

                           ************************ Documents ************************ */

                        // setup:
                        RegexValues regexValues = new RegexValues();
                        string listRegex;

                        // check regex user name:
                        if (!regexValues.UserNameIsValid(nguoiDung.TenDangNhap))
                        {
                            /*
                             * todo: list default = "";
                             */
                            listRegex = "";

                            // show list regex:
                            foreach (string mess in regexValues.messages)
                            {
                                // Add regex message to list:
                                listRegex +=
                                $"<br />" +
                                $". {mess}";
                            }

                            ModelState.AddModelError(
                            // Field Model:
                            "TenDangNhap",
                            // messages:
                            $"User name {nguoiDung.TenDangNhap} " +
                            $"violates our policy: " +
                            // list regex:
                            listRegex
                           );
                        }
                        // Check password regex:
                        else if (!regexValues.IsStrongPassword(nguoiDung.MatKhau))
                        {
                            /*
                             * todo: list default = "";
                             */
                            listRegex = "";

                            // show list regex:
                            foreach (string mess in regexValues.messages)
                            {
                                // Add regex message to list:
                                listRegex +=
                                $"<br />" +
                                $". {mess}";
                            }

                            ModelState.AddModelError(
                            // Field Model:
                            "MatKhau",
                            // messages:
                            $"password " +
                            $"violates our policy: " +
                            // list regex:
                            listRegex
                           );


                        }
                        // Check password regex:
                        else if (!regexValues.PhoneNumberValid(nguoiDung.SDT))
                        {
                            /*
                             * todo: list default = "";
                             */
                            listRegex = "";

                            // show list regex:
                            foreach (string mess in regexValues.messages)
                            {
                                // Add regex message to list:
                                listRegex +=
                                $"<br />" +
                                $". {mess}";
                            }

                            ModelState.AddModelError(
                            // Field Model:
                            "SDT",
                            // messages:
                            $"Phone number " +
                            $"violates our policy: " +
                            // list regex:
                            listRegex
                           );
                        }  else
                      code ...
                    }
                Code ...
        }

```
</details>

