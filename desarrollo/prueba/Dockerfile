FROM node:18.16.0-alpine3.17 as build

WORKDIR /usr/src/app

COPY package*.json ./
RUN npm ci
RUN npm install xlsx

COPY . .

RUN npm run build -- --output-path=./dist/colabmanager360-front --output-hashing=all

# Use a smaller base image for the production environment
FROM nginx:1.21.0-alpine

# Copy the built application to the nginx directory
COPY --from=build /usr/src/app/dist/colabmanager360-front /usr/share/nginx/html

# Copy the nginx configuration file to the container
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Expose port 80 for the nginx server
EXPOSE 80

# Start the nginx server
CMD ["nginx", "-g", "daemon off;"]
