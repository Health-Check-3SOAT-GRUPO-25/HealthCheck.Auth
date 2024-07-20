Write-Host "Apply deployments e services"
kubectl apply -f api-deployment.yml
kubectl apply -f api-svc.yml

kubectl apply -f metricserver-deployment.yml

Write-Host "Apply scale objects (HPA)"
kubectl apply -f api-scaleobject.yml

Write-Host "Os recursos do Kubernetes foram aplicados."