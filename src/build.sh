#!/bin/sh
docker build -f EmployeeService/Dockerfile -t amolenk.azurecr.io/teamassembler-employeeservice:latest EmployeeService
docker build -f TeamService/Dockerfile -t amolenk.azurecr.io/teamassembler-teamservice:latest TeamService
docker build -f WebUI/Dockerfile -t amolenk.azurecr.io/teamassembler-webui:latest WebUI