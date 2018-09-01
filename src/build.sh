#!/bin/sh
docker build -f TeamService/Dockerfile -t amolenk.azurecr.io/teamservice:latest TeamService
docker build -f WebUI/Dockerfile -t amolenk.azurecr.io/webui:latest WebUI