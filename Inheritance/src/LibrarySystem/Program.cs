using part3;



// Person person = new Person(1, "Ahmed", "01000000000");
// // must NOT compile

// Member member = new Member(2, "Ahmed", "01000000000", 3, 0, 0);
// // must NOT compile

// StaffMember staff = new StaffMember(
//     3,
//     "Ali",
//     "01111111111",
//     DateTime.Now,
//     5000);
// // must NOT compile

// Item item = new Item(
//     Guid.NewGuid(),
//     "Some Item",
//     10,
//     5,
//     1);
// // must NOT compile

// student.FullName = "New Name";
// // must NOT compile

// student.LoanHistory.Add(loan);
// // must NOT compile

// book.IsOnLoan = true;
// // must NOT compile


//items

Book book = new Book(
    Guid.NewGuid(),
    "Clean Code",
    2m);

DVD dvd = new DVD(
    Guid.NewGuid(),
    "The Matrix",
    3m);

Magazine magazine = new Magazine(
    Guid.NewGuid(),
    "Tech Monthly",
    4m);

Book anotherBook = new Book(
    Guid.NewGuid(),
    "Design Patterns",
    2m);

Console.WriteLine("Items created.");
Console.WriteLine();


//members
StudentMember student = new StudentMember(
    1,
    "Ahmed Student",
    "01000000000");

PremiumMember premium = new PremiumMember(
    2,
    "Mohamed Premium",
    "01111111111",
    20m);

Console.WriteLine("Members created.");
Console.WriteLine();

//actions

Console.WriteLine("----- Borrow Withdrawn Item -----");

HeadLibrarian head = new HeadLibrarian(
    10,
    "Head Librarian",
    "01222222222",
    new DateTime(2024, 1, 1),
    10000);

head.WithdrawItem(book);

try
{
    student.BorrowItem(book);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine();



Console.WriteLine("----- Borrow Item Already On Loan -----");

student.BorrowItem(dvd);

try
{
    premium.BorrowItem(dvd);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine();



Console.WriteLine("----- Student 4th Loan -----");

student.BorrowItem(magazine);
student.BorrowItem(anotherBook);

// Student currently has:
// DVD
// Magazine
// Design Patterns

Book fourthBook = new Book(
    Guid.NewGuid(),
    "Refactoring",
    2m);

try
{
    student.BorrowItem(fourthBook);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine();




Console.WriteLine("----- Staff Monthly Pay -----");

Librarian librarian = new Librarian(
    20,
    "Library Worker",
    "01333333333",
    new DateTime(2023, 5, 1),
    6000);

Shelver shelver = new Shelver(
    21,
    "Shelf Worker",
    "01444444444",
    new DateTime(2022, 6, 1),
    5000,
    "Fiction");

List<StaffMember> staffMembers = new()
{
    librarian,
    head,
    shelver
};

foreach (StaffMember staff in staffMembers)
{
    Console.WriteLine(
        $"{staff.FullName} - Monthly Pay: {staff.MonthlyPay}");
}

Console.WriteLine();


// ============================================================
// 5. Items in one List
// ============================================================

Console.WriteLine("----- Items -----");

List<Item> items = new()
{
    book,
    dvd,
    magazine
};

foreach (Item item in items)
{
    Console.WriteLine(
        $"{item.Title} - " +
        $"Loan Period: {item.LoanPeriodDays} days - " +
        $"Daily Late Fee: {item.DailyLateFee}");
}

Console.WriteLine();


// ============================================================
// 6. Premium member returns DVD 5 days late
// ============================================================

Console.WriteLine("----- Premium Late Return -----");

// DVD loan period = 7 days.
//
// If we borrow it 12 days ago:
// Due date = 5 days ago
// Return today = 5 days late.

DVD premiumDvd = new DVD(
    Guid.NewGuid(),
    "Premium DVD",
    3m);

DateTime borrowDate = DateTime.Now.AddDays(-12);

Loan premiumLoan = premium.BorrowItem(
    premiumDvd,
    borrowDate);

premium.ReturnItem(premiumDvd);

Console.WriteLine($"Due Date: {premiumLoan.DueDate}");
Console.WriteLine($"Return Date: {premiumLoan.ReturnDate}");
Console.WriteLine($"Late Fee: {premiumLoan.LateFee}");
Console.WriteLine($"Reading Points: {premium.ReadingPoints}");

Console.WriteLine();

