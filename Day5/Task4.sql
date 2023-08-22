USE OFFICE;

--To lists the number of employees in each department.
SELECT Department, COUNT(EmployeeID) AS EmployeeCount FROM Employee GROUP BY Department;