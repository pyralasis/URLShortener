# Step 1: Build the React app
FROM node:18 as build

WORKDIR /app

# Copy the package.json and package-lock.json (or yarn.lock)
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of the app source code
COPY . .

# Build the React app
RUN npm run build

# Step 2: Serve the React app with NGINX
FROM nginx:alpine

# Copy the build folder to NGINX's html folder
COPY --from=build /app/dist /usr/share/nginx/html

COPY /nginx /etc/nginx/conf.d/

# Expose port 80
EXPOSE 80

# Start NGINX
CMD ["nginx", "-g", "daemon off;"]