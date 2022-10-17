﻿

namespace BHD_HRM.Data.App.User;

public class UserServices
{
    static List<UserDto> _datas = new()
    {
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "/img/avatar/4.svg",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k",
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "pdurber1c",
            FullName = "Paulie Durber",
            Email = "pdurber1c@gov.uk",
            HeadImg = "",
            Role = "Subscriber",
            Plan = "Team",
            Status = "Inactive",
            Contact = "(694) 676-1275",
            Country = "Sweden",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "owind1b",
            FullName = "Onfre Wind",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Admin",
            Plan = "Basic",
            Status = "Pending",
            Contact = "(344) 262-7270",
            Country = "Ukraine",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "kcourtliff1a",
            FullName = "Karena Courtliff",
            Email = "kcourtliff1a@bbc.co.uk",
            HeadImg = "/img/avatar/2.svg",
            Role = "Admin",
            Plan = "Basic",
            Status = "Active",
            Contact = "(478) 199-0020",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "soffner19",
            FullName = "Saunder Offner",
            Email = "soffner19@mac.com",
            HeadImg = "/img/avatar/3.svg",
            Role = "Maintainer",
            Plan = "Basic",
            Status = "Pending",
            Contact = "(200) 586-2264",
            Country = "Poland",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "cperot18",
            FullName = "Corrie Perot",
            Email = "cperot18@goo.ne.jp",
            HeadImg = "",
            Role = "Subscriber",
            Plan = "Basic",
            Status = "Pending",
            Contact = "(659) 385-6808",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "vkoschek17",
            FullName = "Vladamir Koschek",
            Email = "vkoschek17@abc.net.au",
            HeadImg = "",
            Role = "Author",
            Plan = "Basic",
            Status = "Active",
            Contact = "(531) 758-8335",
            Country = "Guatemala",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "mmcnirlan16",
            FullName = "Micaela McNirlan",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Admin",
            Plan = "Basic",
            Status = "Indonesia",
            Contact = "(242) 952-0916",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "brossiter15",
            FullName = "Benedetto Rossiter",
            Email = "brossiter15@craigslist.org",
            HeadImg = "",
            Role = "Editor",
            Plan = "Basic",
            Status = "Inactive",
            Contact = "(323) 175-6741",
            Country = "Indonesia",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "ebaldetti14",
            FullName = "Edwina Baldetti",
            Email = "ebaldetti14@theguardian.com",
            HeadImg = "/img/avatar/7.svg",
            Role = "Maintainer",
            Plan = "BAsic",
            Status = "Pending",
            Contact = "(315) 329-3578",
            Country = "Haiti",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "fdesporte13",
            FullName = "Florenza Desporte",
            Email = "fdesporte13@omniture.com",
            HeadImg = "",
            Role = "Author",
            Plan = "Basic",
            Status = "Active",
            Contact = "(312) 104-2638",
            Country = "Ukraine",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "twidmore12",
            FullName = "Tyne Widmore",
            Email = "twidmore12@bravesites.com",
            HeadImg = "",
            Role = "Subscriber",
            Plan = "Basic",
            Status = "Pending",
            Contact = "(531) 731-0928",
            Country = "Finland",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "mpiccard11",
            FullName = "Moritz Piccard",
            Email = "mpiccard11@vimeo.com",
            HeadImg = "/img/avatar/8.svg",
            Role = "Maintainer",
            Plan = "Basic",
            Status = "Inactive",
            Contact = "(365) 277-2986",
            Country = "Croatia",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "shebblethwaite10",
            FullName = "Skip Hebblethwaite",
            Email = "shebblethwaite10@arizona.edu",
            HeadImg = "/img/avatar/9.svg",
            Role = "Admin",
            Plan = "Basic",
            Status = "Inactive",
            Contact = "(610) 343-1024",
            Country = "Canada",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "brosebothamz",
            FullName = "Bradan Rosebotham",
            Email = "brosebothamz@tripadvisor.com",
            HeadImg = "",
            Role = "Subscriber",
            Plan = "Basic",
            Status = "Inactive",
            Contact = "(882) 933-2180",
            Country = "Belarus",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "smacgilfoyley",
            FullName = "Stephen MacGilfoyle",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Maintainer",
            Plan = "Basic",
            Status = "Pending",
            Contact = "(397) 294-5153",
            Country = "Japan",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "ofibbensx",
            FullName = "Ophelie Fibbens",
            Email = "ofibbensx@booking.com",
            HeadImg = "/img/avatar/10.svg",
            Role = "Editor",
            Plan = "Basic",
            Status = "Active",
            Contact = "(764) 885-7351",
            Country = "Indonesia",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "/img/avatar/11.svg",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "/img/avatar/12.svg",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "/img/avatar/13.svg",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "/img/avatar/14.svg",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        },
        new UserDto("Pending", "Subscriber", DateOnly.FromDateTime(DateTime.Now), "(895) 401-4255", "Male", GetPermissionsList())
        {
            UserName = "bkrabbe1d",
            FullName = "Beverlie Krabbe",
            Email = "bkrabbe1d@home.pl",
            HeadImg = "",
            Role = "Editor",
            Plan = "Company",
            Status = "Active",
            Contact = "(397) 294-5153",
            Country = "China",
            Profit = "$99.87k",
            Sales = "23.3k"
        }
    };

    public static List<UserDto> GetList() => _datas;

    public static Dictionary<string, string> GetRoleIconMap() => new()
    {
        ["Editor"] = "mdi-pencil,info",
        ["Subscriber"] = "mdi-account,pry",
        ["Admin"] = "mdi-account-edit,error",
        ["Maintainer"] = "mdi-database,sample-green",
        ["Author"] = "mdi-cog,remind",
    };

    public static List<string> GetPlanList() => new List<string>
    {
        "Basic", "Company", "Enterprise", "Team",
    };

    public static List<string> GetStatusList() => new List<string>
    {
        "Pending", "Active", "Inactive",
    };

    public static List<string> GetEducateList() => new List<string>
    {
        "Sau đại học", "Đại học", "Cao đẳng", "Trung cấp", "12/12",
    };

    public static List<string> GetContracttypeList() => new List<string>
    {
        "Có thời hạn", "Vô thời hạn",
    };

    public static List<string> GetTrangThaiList() => new List<string>
    {
         "Chờ Update","Thử việc","Full Time","Part Time","Đã nghỉ việc",
    };

    public static List<string> GetRoleList() => new List<string>
    {
        "Admin","Board of Directors","Manager","Senior","Employess"
    };

    public static List<PermissionDto> GetPermissionsList() => new List<PermissionDto>()
    {
        new PermissionDto() { Module="Admin", Read = true },
        new PermissionDto() { Module="Staff", Write = true },
        new PermissionDto() { Module="Author", Read = true, Create = true },
        new PermissionDto() { Module="Contributor" },
        new PermissionDto() { Module="User", Delete = true },
    };


}

