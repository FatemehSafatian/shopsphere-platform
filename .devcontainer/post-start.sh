#!/bin/bash

# Wait until Docker is ready
for i in {1..30}; do
  docker info > /dev/null 2>&1 && break
  sleep 2
done

# Create the kind cluster if it doesn't exist
if ! kind get clusters | grep -q '^kind$'; then
  kind create cluster
fi

# Load images into the cluster
# (the kind node can't pull images by itself in Codespaces - DNS issue)
for image in nginx:1.27 mongo:7; do
  docker pull "$image"
  docker save "$image" | docker exec -i kind-control-plane ctr --namespace=k8s.io images import -
done