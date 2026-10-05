using SrpLab;
using SrpLab.Appointment;
using SrpLab.Checkout;
using SrpLab.CourseEnrollment;
using SrpLab.GradeBookF;
using SrpLab.Kitchen;
using SrpLab.Loan;
using SrpLab.SubscriptionBill;
using SrpLab.Ward;
using SrpLab.SupportTickets;
using SrpLab.Warehouse;

Console.WriteLine("SrpLab — 10 intentional SRP violations (refactor me)");
Console.WriteLine("=================================================");

var ward = new WardBoard();

ward.AssignBed(
    1,
    "p-88",
    heartRate: 130,
    spo2: 89);

// Handoff note
var handoffGenerator = new HandoffNoteGenerator();

var patient = ward.Patients[1];
var acuity = ward.AcuityScores[1];

Console.WriteLine(
    handoffGenerator.Generate(
        1,
        patient,
        acuity));

// Pager
var pager = new PagerAlert();

pager.CheckAndRecord(1, acuity);

Console.WriteLine(
    string.Join(" | ", pager.DrainLog()));
//========================================================================================
var basket = new CheckoutBasket();
var PaymentAutu=new PaymentAuthorization();

basket.AddLine("SKU-1", 40m, 2);
basket.ApplyCouponText("SAVE10");
basket.EnableGiftWrap();
Console.WriteLine($"basket total={basket.GrandTotal()} auth={PaymentAutu.AuthorizePaymentStub("4242",basket.GrandTotal(),basket.GetLinesCount())}");
// ===========================-==============================================================================
var ticket = new SupportTicket(
    "T-1",
    "cannot login",
    "prod is down for me",
    DateTimeOffset.UtcNow);

var replyGenerator = new ReplyGenerator();

var reply = replyGenerator.Generate(
    ticket.Id,
    ticket.Priority,
    "Nora",
    ticket.SlaDeadline());

Console.WriteLine(reply);
//======================================================================================================
var loan = new LoanDesk(
    60_000m,
    640,
    4,
    hasCollateral: false);

var riskScore = loan.RiskScore();
var isEligible = loan.IsEligible();

var documentsProvider = new RequiredDocument();

var documents = documentsProvider.GetRequiredDocuments(
    loan.RequestedAmount,
    loan.HasCollateral,
    loan.EmploymentMonths,
    isEligible);

var letterGenerator = new DecisionLetterGenerator();

var letterr = letterGenerator.Generate(
    "Omar",
    loan.RequestedAmount,
    riskScore,
    isEligible,
    documents);

Console.WriteLine(letterr);
//////==============================================================================================================
var course = new CourseEnrollmentDesk("SEF-101", capacity: 1, tuition: 3000m);
var WelcomePacket=new WelcomePacketGenerator();
Console.WriteLine(course.Register("a@mail.com"));
Console.WriteLine(course.Register("b@mail.com"));
Console.WriteLine(WelcomePacket.WelcomePacketMarkdown("b@mail.com", "Bea",course.CourseCode,course.IsSeated("b@mail.com"),course.WaitlistPosition("b@mail.com")));
//================================================================================================================
var kitchen = new KitchenTicket();

kitchen.AddItem(
    "Pasta",
    new[] { "wheat", "milk" },
    12);

var allergenDetector = new AllergenDetector();

var allergens = allergenDetector.Detect(
    kitchen.Items.Select(x => x.Ingredients));

var etaCalculator = new KitchenCalculator();

var eta = etaCalculator.Calculate(
    kitchen.Items,
    openStations: 2,
    allergenCount: allergens.Count);

var renderer = new ThermalTicket();

var tickett = renderer.Render(
    orderNumber: 42,
    items: kitchen.Items,
    estimatedMinutes: eta,
    allergens: allergens);

Console.WriteLine(tickett);

var laneSelector = new ExpoLaneSelector();

var lane = laneSelector.Select(
    hasAllergens: allergens.Count > 0,
    estimatedMinutes: eta);

Console.WriteLine(lane);
//=========================================================================================================
var sub = new SubscriptionBilling("c-9", 99m, new DateOnly(2026, 9, 1), new DateOnly(2026, 10, 1));
sub.RegisterFailedPayment();
var email = new DunningEmailGenerator().Generate(
    "Sara",
    new DateOnly(2026, 9, 20),
    sub.Prorate(sub.PeriodStart),
    sub.NextInvoiceNumber(),
    sub.FailedPayments);

Console.WriteLine(email);

///====================================================================================================================
var pick = new WarehousePickList();

pick.AddNeed("BOLT", "A", 3, 10, 7);
pick.AddNeed("NUT", "B", 1, 5, 5);

var routeCalculator = new PickingCalculator();

var walkingOrder = routeCalculator.Calculate(pick.Lines);

var allocations = pick.Allocate();

var scriptGenerator = new PickerGenerator();

var script = scriptGenerator.Generate(
    walkingOrder,
    allocations,
    pick.Lines);

Console.WriteLine(script);
//=========================================================================================================

var grades = new GradeBook();

var transcript=new TranscriptGenerator();

var letter=new LetterGradePolicy();

var honor=new HonorPolicy();

decimal average=grades.Average("s1");
grades.Record("s1", 92);
grades.Record("s1", 88);
Console.WriteLine(transcript.Generate("s1", "Ali",average,letter.GetLetter(average),honor.Meets(average,letter.GetLetter(average))));
//==========================================================================================================
var appt = new AppointmentDesk(new TimeOnly(9, 0), new TimeOnly(17, 0), 30);
var sms=new SmsRemainder();
var slot = appt.FindNextSlot(DateTimeOffset.Parse("2026-09-21T08:00:00Z"), 48);
if (slot is null) throw new InvalidOperationException("no slot");
appt.TryBook(slot.Value);
Console.WriteLine(sms.SmsReminder(slot.Value, "0100"));

Console.WriteLine("Done. Now split responsibilities — without breaking behavior.");
