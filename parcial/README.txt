Desarrollo de Servicios Web
Una clínica privada necesita gestionar las citas médicas que los pacientes solicitan a diario.
Actualmente, las citas se anotan manualmente en agendas físicas o se 
confirman por llamadas telefónicas sin un control unificado, lo que genera confusión, pérdida de información y sobrecarga para el personal administrativo.
Para solucionar este problema, como parte del equipo de desarrollo backend, usted y dos integrantes más han sido asignados para construir una API RESTful con C# 
y .Net Core, con el objetivo de registrar, consultar, actualizar y cancelar citas médicas de manera eficiente y ordenada





--------------CITAS--------------------
GET     | http://localhost:5260/api/citas

GET{id} | http://localhost:5260/api/citas/{id}

POST    | http://localhost:5260/api/citas

PUT     | http://localhost:5260/api/citas/{id}

DELETE  | http://localhost:5260/api/citas/{id}

--------------MEDICOS--------------------
GET     | http://localhost:5260/api/medicos

GET{id} | http://localhost:5260/api/medicos/{id}

POST    | http://localhost:5260/api/medicos

PUT     | http://localhost:5260/api/medicos/{id}

DELETE  | http://localhost:5260/api/medicos/{id}

--------------PACIENTES--------------------
GET     | http://localhost:5260/api/pacientes

GET{id} | http://localhost:5260/api/pacientes/{id}

POST    | http://localhost:5260/api/pacientes

PUT     | http://localhost:5260/api/pacientes/{id}

DELETE  | http://localhost:5260/api/pacientes/{id}