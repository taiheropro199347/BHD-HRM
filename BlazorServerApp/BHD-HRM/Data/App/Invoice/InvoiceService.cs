
namespace BHD_HRM.Data.App.Invoice;

public static class InvoiceService
{
    public static List<InvoiceRecordDto> GetInvoiceRecordList() => new()
    {
        new InvoiceRecordDto(UserServices.GetList()[0]) { Id = 0, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 1 },
        new InvoiceRecordDto(UserServices.GetList()[1]) { Id = 1, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 1 },
        new InvoiceRecordDto(UserServices.GetList()[2]) { Id = 2, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 2 },
        new InvoiceRecordDto(UserServices.GetList()[3]) { Id = 3, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 3 },
        new InvoiceRecordDto(UserServices.GetList()[4]) { Id = 4, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 4 },
        new InvoiceRecordDto(UserServices.GetList()[5]) { Id = 5, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 5 },
        new InvoiceRecordDto(UserServices.GetList()[6]) { Id = 6, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 1 },
        new InvoiceRecordDto(UserServices.GetList()[7]) { Id = 7, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 2 },
        new InvoiceRecordDto(UserServices.GetList()[8]) { Id = 8, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 3 },
        new InvoiceRecordDto(UserServices.GetList()[9]) { Id = 9, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 4 },
        new InvoiceRecordDto(UserServices.GetList()[10]) { Id = 10, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 5 },
        new InvoiceRecordDto(UserServices.GetList()[11]) { Id = 11, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 1 },
        new InvoiceRecordDto(UserServices.GetList()[12]) { Id = 12, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 2 },
        new InvoiceRecordDto(UserServices.GetList()[13]) { Id = 13, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 3 },
        new InvoiceRecordDto(UserServices.GetList()[14]) { Id = 14, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 4 },
        new InvoiceRecordDto(UserServices.GetList()[15]) { Id = 16, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 5 },
        new InvoiceRecordDto(UserServices.GetList()[16]) { Id = 15, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 1 },
        new InvoiceRecordDto(UserServices.GetList()[17]) { Id = 17, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 2 },
        new InvoiceRecordDto(UserServices.GetList()[18]) { Id = 18, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 3 },
        new InvoiceRecordDto(UserServices.GetList()[19]) { Id = 19, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 4 },
        new InvoiceRecordDto(UserServices.GetList()[20]) { Id = 20, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 5 },
        new InvoiceRecordDto(UserServices.GetList()[21]) { Id = 21, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 1 },
        new InvoiceRecordDto(UserServices.GetList()[22]) { Id = 22, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 2 },
        new InvoiceRecordDto(UserServices.GetList()[23]) { Id = 23, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 3 },
        new InvoiceRecordDto(UserServices.GetList()[24]) { Id = 34, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 4 },
        new InvoiceRecordDto(UserServices.GetList()[25]) { Id = 25, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 5 },
        new InvoiceRecordDto(UserServices.GetList()[26]) { Id = 26, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 1 },
        new InvoiceRecordDto(UserServices.GetList()[27]) { Id = 27, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 2 },
        new InvoiceRecordDto(UserServices.GetList()[28]) { Id = 28, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 3 },
        new InvoiceRecordDto(UserServices.GetList()[29]) { Id = 29, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 4 },
        new InvoiceRecordDto(UserServices.GetList()[30]) { Id = 30, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 5 },
        new InvoiceRecordDto(UserServices.GetList()[31]) { Id = 31, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 1 },
        new InvoiceRecordDto(UserServices.GetList()[32]) { Id = 32, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 2 },
        new InvoiceRecordDto(UserServices.GetList()[33]) { Id = 33, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 3 },
        new InvoiceRecordDto(UserServices.GetList()[34]) { Id = 34, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 4 },
        new InvoiceRecordDto(UserServices.GetList()[35]) { Id = 35, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 5 },
        new InvoiceRecordDto(UserServices.GetList()[36]) { Id = 36, Balance = 205, Total = 3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 1 }
    };

    public static List<BillDto> GetBillList() => new()
    {
        new BillDto("App Design", 24, 1, 24, "Designed UI kit & app pages."),
        new BillDto("App Customization", 26, 1, 26, "Customization & Bug Fixes."),
        new BillDto("ABC Template", 28, 1, 28, "Bootstrap 4 admin template."),
        new BillDto("App Development", 32, 1, 32, "Native App Development."),
    };

    public static List<InvoiceStateDto> GetStateList() => new()
    {
        new InvoiceStateDto("Downloaded", 1),
        new InvoiceStateDto("Draft", 2),
        new InvoiceStateDto("Paid", 3),
        new InvoiceStateDto("Partial Payment", 4),
        new InvoiceStateDto("Past Due", 5)
    };

    public static PagingData<InvoiceRecordDto> GetInvoiceRecordList(int pageIndex, int pageSize, int state)
    {
        var invoiceRecordList = GetInvoiceRecordList();

        var items = invoiceRecordList
            .Where(a => a.State == state || state == 0)
            .OrderBy(a => a.Id)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return new PagingData<InvoiceRecordDto>(pageIndex, pageSize, invoiceRecordList.Count, items);
    }

    public static List<string> GetpaymentMethodList() => new()
    {
        "Cash",
        "Bank Transfer",
        "Debit",
        "Credit",
        "Paypal"
    };
}

