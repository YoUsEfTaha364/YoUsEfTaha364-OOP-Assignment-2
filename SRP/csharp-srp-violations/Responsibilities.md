# Responsibilities

1. AppointmentDesk

Responsibilities:
- Find available appointment slots.
- Book appointments.
- Generate calendar/ICS data.
- Generate SMS reminder messages.

 These responsibilities have different reasons to change. For example, business hours may change independently from the calendar format or SMS message wording.



2. CheckoutBasket

Responsibilities:
- Manage items in the shopping basket.
- Calculate the subtotal and final total.
- Parse and apply coupon codes.
- Handle gift-wrap pricing.
- Generate gift message content.
- Handle payment authorization.

Problem: Shopping calculations, coupon rules, marketing messages, and payment logic are unrelated concerns and may change independently.


3. CourseEnrollmentDesk

Responsibilities:
- Register students in a course.
- Manage course capacity.
- Manage the waiting list.
- Promote students from the waiting list.
- Generate welcome-packet content.
- Generate tuition invoice information.

 Enrollment rules, marketing content, and financial formatting have different reasons to change and should not be controlled by the same class.


4. GradeBook

Responsibilities:
- Store and record student scores.
- Calculate student averages.
- Determine letter grades.
- Determine honor-roll eligibility.
- Generate transcript content.
- Export grades as CSV.

Problem: Grade calculations and academic policies are different from document formatting and CSV export. A change to the export format should not require changing grading logic.


5. KitchenTicket

Responsibilities:
- Manage kitchen order items.
- Detect allergens.
- Estimate food preparation time.
- Generate the printed kitchen ticket.
- Decide the kitchen/expo lane.

Food safety rules, kitchen timing, printer formatting, and operational routing are separate concerns that can change independently.



6. LoanDesk

Responsibilities:
- Calculate loan risk.
- Determine loan eligibility.
- Determine required documents.
- Generate decision letters.
- Export loan information for underwriters.

Risk calculations, compliance requirements, communication templates, and reporting formats are different responsibilities with different reasons to change.



7. SubscriptionBilling

Responsibilities:
- Calculate subscription proration.
- Generate invoice numbers.
- Track failed payments.
- Generate dunning emails.
- Generate accounting/ledger export data.

Billing calculations, invoice numbering, customer communication, and accounting formats are independent concerns and should not be handled by one class.



8. SupportTicket

Responsibilities:
- Store and update support ticket information.
- Determine ticket priority from its text.
- Calculate SLA deadlines.
- Check whether the SLA has been breached.
- Generate public customer replies.
- Generate internal escalation messages.

Priority detection, SLA rules, and message templates belong to different areas of the system and may change independently.



9. WardBoard

Responsibilities:
- Assign patients to beds.
- Calculate patient acuity scores.
- Decide when a pager alert should be triggered.
- Generate nurse handoff notes.
- Manage pager logs.
- Export ward census data.

Clinical calculations, alerting policies, presentation, and data export are separate concerns. Changing one should not require changing the others.



10. WarehousePickList

Responsibilities:
- Store warehouse picking requirements.
- Allocate available stock.
- Calculate the walking order for pickers.
- Generate picker instructions.
- Generate WMS XML data.

tock allocation, warehouse routing, user instructions, and external integration formats are different responsibilities and can change for different reasons.