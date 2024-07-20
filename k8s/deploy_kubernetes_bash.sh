#!/bin/bash

export PATH=$PATH:/c/Windows/system32

echo "Apply deployments e services"
"$kubectl" apply -f api-deployment.yml
"$kubectl" apply -f api-svc.yml

"$kubectl" apply -f metricserver-deployment.yml

echo "Apply scale objects (HPA)"
"$kubectl" apply -f api-scaleobject.yml

echo "Os recursos do Kubernetes foram aplicados."