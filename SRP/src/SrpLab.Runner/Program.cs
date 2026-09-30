using SrpLab;
using SrpLab.CourseEnrollmentDesk;
using SrpLab.GradeBook;
using SrpLab.KitchenTicket;
using SrpLab.Loan_Desk;
using SrpLab.SubscriptionBilling;
using SrpLab.SupportTicket;
using SrpLab.Warehouse_PickList;

Console.WriteLine("SrpLab — Refactored SRP classes");
Console.WriteLine("================================");

// =========================
// WardBoard
// =========================

var ward = new SrpLab.WardBoard.WardBoard();

ward.AssignBed(
    1,
    "p-88",
    heartRate: 130,
    spo2: 89);

Console.WriteLine(ward.BuildHandoffNote(1));
Console.WriteLine(
    string.Join(" | ", ward.DrainPagerLog()));


// =========================
// CheckoutBasket
// =========================

var basket = new CheckoutBasket();

basket.AddLine(
    "SKU-1",
    40m,
    2);

basket.ApplyCouponText("SAVE10");
basket.EnableGiftWrap();

Console.WriteLine(
    $"basket total={basket.GrandTotal()} " +
    $"auth={basket.AuthorizePaymentStub("4242")}");


// =========================
// SupportTicket
// =========================

var ticket = new SupportTicket(
    "T-1",
    "cannot login",
    "prod is down for me",
    DateTimeOffset.UtcNow);

var priorityClassifier =
    new SupportPriorityClassifier();

ticket.SetPriority(
    priorityClassifier.CalculatePriority(
        ticket.Subject,
        ticket.Body));

var slaCalculator =
    new SupportSlaCalculator();

var deadline =
    slaCalculator.SlaDeadline(
        ticket.OpenedAt,
        ticket.Priority);

var replyGenerator =
    new SupportReplyGenerator();

Console.WriteLine(
    replyGenerator.Generate(
        ticket,
        "Nora",
        deadline));


// =========================
// LoanDesk
// =========================

var loan =
    new LoanDesk(
        60_000m,
        640,
        4,
        hasCollateral: false);

var loanDecisionLetter =
    new LoanDecisionLetter();

Console.WriteLine(
    loanDecisionLetter.Generate(
        loan,
        "Omar"));


// =========================
// CourseEnrollmentDesk
// =========================

var course =
    new CourseEnrollmentDesk(
        "SEF-101",
        capacity: 1,
        tuition: 3000m);

Console.WriteLine(
    course.Register("a@mail.com"));

Console.WriteLine(
    course.Register("b@mail.com"));

Console.WriteLine(
    course.WelcomePacketMarkdown(
        "b@mail.com",
        "Bea"));


// =========================
// KitchenTicket
// =========================

var kitchen =
    new KitchenTicket();

kitchen.AddItem(
    "Pasta",
    new[] { "wheat", "milk" },
    12);

var allergenDetector =
    new AllergenDetector();

var allergens =
    allergenDetector.Detect(
        kitchen.Items);

var readyTimeEstimator =
    new KitchenReadyTimeEstimator();

var readyMinutes =
    readyTimeEstimator.Estimate(
        kitchen.Items,
        2,
        allergens.Count);

var thermalRenderer =
    new ThermalTicketRenderer();

Console.WriteLine(
    thermalRenderer.Render(
        42,
        kitchen.Items,
        allergens,
        readyMinutes));


// =========================
// SubscriptionBilling
// =========================

var sub =
    new SubscriptionBilling(
        "c-9",
        99m,
        new DateOnly(2026, 9, 1),
        new DateOnly(2026, 10, 1));

sub.RegisterFailedPayment();

var dunningEmailGenerator =
    new DunningEmailGenerator();

Console.WriteLine(
    dunningEmailGenerator.Generate(
        sub,
        "Sara",
        new DateOnly(2026, 9, 20)));


// =========================
// WarehousePickList
// =========================

var pick =
    new WarehousePickList();

pick.AddNeed(
    "BOLT",
    "A",
    3,
    10,
    7);

pick.AddNeed(
    "NUT",
    "B",
    1,
    5,
    5);

var walkingPlanner =
    new WarehouseWalkingPlanner();

var walkingOrder =
    walkingPlanner.CreateOrder(
        pick.Lines);

var stockAllocator =
    new StockAllocator();

var allocations =
    stockAllocator.Allocate(
        pick.Lines);

var pickerScriptGenerator =
    new PickerScriptGenerator();

Console.WriteLine(
    pickerScriptGenerator.Generate(
        walkingOrder,
        allocations,
        pick.Lines));


// =========================
// GradeBook
// =========================

var grades =
    new GradeBook();

grades.Record(
    "s1",
    92);

grades.Record(
    "s1",
    88);

var gradePolicy =
    new GradePolicy();

var honorRollPolicy =
    new HonorRollPolicy();

var average =
    grades.Average("s1");

var letter =
    gradePolicy.Letter(average);

var honor =
    honorRollPolicy.MeetsHonorRoll(
        average,
        letter);

var transcriptFormatter =
    new TranscriptFormatter();

Console.WriteLine(
    transcriptFormatter.Format(
        "s1",
        "Ali",
        average,
        letter,
        honor));


// =========================
// AppointmentDesk
// =========================

var appt =
    new AppointmentDesk(
        new TimeOnly(9, 0),
        new TimeOnly(17, 0),
        30);

var slot =
    appt.FindNextSlot(
        DateTimeOffset.Parse(
            "2026-09-21T08:00:00Z"),
        48);

if (slot is null)
{
    throw new InvalidOperationException(
        "no slot");
}

appt.TryBook(slot.Value);

Console.WriteLine(
    appt.SmsReminder(
        slot.Value,
        "0100"));


Console.WriteLine(
    "Done. SRP responsibilities are split without breaking behavior.");