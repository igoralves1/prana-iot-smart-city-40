# Imagem do aplicativo web do Gateway ADW300 -> AWS IoT Core
FROM python:3.11-slim

WORKDIR /app
COPY requirements.txt .
RUN pip install --no-cache-dir -r requirements.txt
COPY . /app/

# config.yml e certificates/ sao montados em / pelo docker-compose
ENV CONFIG_FILE=/config.yml
EXPOSE 8000
CMD ["uvicorn", "web:app", "--host", "0.0.0.0", "--port", "8000"]
