# Clean previous builds
echo "Cleaning project...."
dotnet clean 

# Build the project in Release mode
echo "Building project (release)...."
dotnet publish --configuration Release 

# Clean just in case
echo "Removing stopped containers...."
docker system prune -f

# Clear docker cache
echo "Clearing docker cache...."
docker builder prune -f

# Compose new images
echo "Building images...."
docker build -t e-commerce-app .






