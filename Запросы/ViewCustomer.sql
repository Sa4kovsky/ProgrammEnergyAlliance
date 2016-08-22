SELECT Customer.idCustomer, Customer.nameInstitution, NameCustomer.nameNameCustomer,
Customer.LegalAddress, Customer.addressWork, Customer.checkingAccount, Bank.nameBank,Customer.mfo,Customer.unp,Customer.okpo
FROM Customer
	INNER JOIN NameCustomer 
		ON NameCustomer.idNameCustomer = Customer.idNameCustomer
	INNER JOIN Bank 
		ON Bank.idBank = Customer.idBank
	