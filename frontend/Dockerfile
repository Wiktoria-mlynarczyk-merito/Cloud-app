FROM node:20

WORKDIR /app

COPY . .

RUN npm install

EXPOSE 8080

CMD ["npm", "run", "dev", "--", "--port", "8080", "--host"]