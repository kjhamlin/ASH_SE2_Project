# ASH_SE2_Project
Interview project for American Specialty Health\
This project contains a revised DBSchema for the database tables presented in the prompt, and I am adding an explanation for the revision here:\
  By combining all 'workers' in to one table, we remove the need to assign workers to specific tables based on their roles and instead keep all of our employees/manager/supervisors in one place.\
  Next, we separate out the 'compensation' portion of the table, in favor of using a second table and to preserve our 3rd normal form - by using a seperate table, now we can use a foreign key pointing to 
  a worker's specific ID, look up what type of payment they have (in this case, salary or hourly) and then look at their 'pay' field to see how much they are paid on the previously mentioned basis. This also
  avoids awkward 'hourlyPay' columns being null for managers, and 'salary' columns being null for Employees.\
  In addition, by adding XRef tables we prime the database for quick lookups based on compensation type or employment type, a simple addition to maintain a fast database.
