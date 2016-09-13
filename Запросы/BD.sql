--DROP TABLE Executor,Works,Bank,Customer,NameCustomer,Contracts,Score,Materials CASCADE;

CREATE TABLE Executor(
	idExecutor SERIAL PRIMARY KEY,  --идентифицирующий ключ
	nameExecutor text,  --имя исполнителя
	nameExecutors text,  --имя исполнителя в Р.п
	positionExecutor text, --должность
	positionExecutors text, --должность в Р.п
	actingOnTheBasis text, --действующий на основании ... СПИСОК В ПРОГЕ
	number text, --номер приказа...
	date text --дата приказа...
);

CREATE TABLE Works(
	idWorks SERIAL PRIMARY KEY,  --идентифицирующий ключ
	worksType text  --тип работы
);

CREATE TABLE Bank(
	idBank SERIAL PRIMARY KEY, --ключ
	nameBank text, --название банка
	address text --мфо
);

CREATE TABLE Customer(
	idCustomer SERIAL PRIMARY KEY, --ключ
	nameInstitution text, --название учереждения 
	LegalAddress text, --юр адресс
	addressWork text, --адресс где производятся работы
	checkingAccount text, --расчетный счет
	idBank integer,
	unp text,
	okpo text,
	
	FOREIGN KEY (idBank) REFERENCES Bank(idBank)
);

CREATE TABLE NameCustomer(
	idNameCustomer SERIAL PRIMARY KEY,  --идентифицирующий ключ
	idCustomer integer, --название учреждения 
	nameNameCustomer text,  --имя подписчик
	nameNameCustomers text,  --имя подписчик в Р.п
	positionNameCustomer text, --должность
	positionNameCustomers text, --должность в Р.п
	actingOnTheBasis text, --действующий на основании ... СПИСОК В ПРОГЕ
	number text, --номер приказа...
	date text, --дата приказа...

	FOREIGN KEY (idCustomer) REFERENCES Customer(idCustomer)
);


CREATE TABLE Contracts (
	idContrects SERIAL PRIMARY KEY,  --идентифицирующий ключ
	numberContrects integer, --номер договора
	signWork text, --признак работ (буква) СПИСОК В ПРОГЕ
	idExecutor integer,
	idCustomer integer,
	idNameCustomer integer,
	financing text, --финаннсирование СПИСОК В ПРОГЕ
	idWorks integer,
	dateStart text,--дата начала работ
	dateFinish text, --дата окончания работ
	costServices text, --стоимость услуг
	prepayment text, --аванс СПИСОК
	sumPrepayment text, --сумма аванса
	addressWork text,
	
	FOREIGN KEY (idExecutor) REFERENCES Executor(idExecutor), 
	FOREIGN KEY (idCustomer) REFERENCES Customer(idCustomer) Contracts(idContrects) ON DELETE CASCADE,
	FOREIGN KEY (idNameCustomer) REFERENCES NameCustomer(idNameCustomer), 
	FOREIGN KEY (idWorks) REFERENCES Works(idWorks)
);

CREATE TABLE Score --счет
(
	idScore SERIAL PRIMARY KEY,
	idContrects integer,
	address text,
	oneFlow integer,
	twoFlow integer,
	threeFlow integer,
	manometer integer,

	FOREIGN KEY (idContrects) REFERENCES Contracts(idContrects) ON DELETE CASCADE
);

CREATE TABLE Materials --материалы
(
	idMaterials SERIAL PRIMARY KEY,
	idCustomer integer,	--учреждение
	address text, --адрес где стоит
	typeCounter text,--тип счетчика (однопоточный, двух, трех, манометр)
	typeAccount text, --тип учета
	brandEnergyMeter text, --марка теплосчетчика
	du text,
	tb text,
	ipp text,
	ppr text,
	tsp text,
	note text,
	data text,

	FOREIGN KEY (idCustomer) REFERENCES Customer(idCustomer) ON DELETE CASCADE
);

CREATE TABLE Equipment --оборудование
(
	idEquipment SERIAL PRIMARY KEY,
	idCustomer integer,	--учреждение
	address text, --адрес где стоит
	typeEquipment text,--вид оборуд
	typeAccount text, --тип учета
	brandEquipment text, --марка теплосчетчика
	du text,
	brandValves text,
	note text, 
	
	FOREIGN KEY (idCustomer) REFERENCES Customer(idCustomer) ON DELETE CASCADE
);




