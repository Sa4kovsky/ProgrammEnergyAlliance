select count(idMaterials), Customer.nameInstitution
from  Materials ,Customer
where typeCounter like '%однопоточное%' 
and address like '%г.Гомель ул.Суркова д.12%'
and Materials.idCustomer=Customer.idCustomer
GROUP BY nameInstitution
