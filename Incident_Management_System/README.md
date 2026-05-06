FOLDER STRUCTURE

IMS/
 ├── Controllers/
 │    ├── SignalController.cs
 │    ├── WorkItemController.cs
 │    └── RCAController.cs
 ├── Models/
 │    ├── Signal.cs
 │    ├── WorkItem.cs
 │    ├── RCA.cs
 │    └── User.cs
 ├── Data/
 │    └── AppDbContext.cs
 ├── Services/
 │    ├── IncidentService.cs
 │    ├── MongoService.cs
 │    └── AuthService.cs
 ├── Queue/
 │    └── SignalQueue.cs
 ├── Workers/
 │    └── SignalWorker.cs
 ├── Program.cs
 ├── appsettings.json




 src/
 ├── pages/
 │    ├── Dashboard.js
 │    ├── Detail.js
 │    └── RCAForm.js
 ├── App.js



 # 🚨 Incident Management System (IMS)

## 📌 Overview

This project is a **Mission-Critical Incident Management System** designed to handle high-throughput system signals (10,000/sec), process them asynchronously, and manage incident lifecycle with mandatory RCA enforcement.

---

## 🧠 Architecture

### 🔁 Flow

```
Client → API → In-Memory Queue → Background Worker
                             → MongoDB (Signals)
                             → SQL Server (WorkItems)
                             → Redis (Dashboard - optional)
```

---

## 🧩 Tech Stack

| Layer     | Technology           |
| --------- | -------------------- |
| Backend   | ASP.NET Core Web API |
| Queue     | In-Memory Channel    |
| SQL DB    | SQL Server / LocalDB |
| NoSQL     | MongoDB              |
| Frontend  | React                |
| Container | Docker               |

---

## ⚙️ Features

### ✅ High Throughput Ingestion

* Handles burst traffic using async queue (Channel)

### ✅ Debouncing Logic

* Prevents duplicate incidents within 10 seconds

### ✅ Dual Storage

* MongoDB → raw signals (audit log)
* SQL → structured incidents (source of truth)

### ✅ Workflow Engine

* OPEN → INVESTIGATING → RESOLVED → CLOSED

### ✅ Mandatory RCA

* Incident cannot be closed without RCA

### ✅ MTTR Calculation

* Automatically calculated from start to closure

### ✅ Background Processing

* Worker processes signals asynchronously

---

## 🔐 (Optional) Authentication

* JWT-based authentication
* Role-based access (Admin/User)

---

## 🖥️ Frontend

* Dashboard: View active incidents
* Detail Page: View incident info
* RCA Form: Submit root cause & fix

---

## 🚀 Setup Instructions

### 1️⃣ Clone Repo

```
git clone <your-repo>
cd IMS
```

---

### 2️⃣ Run with Docker (Recommended)

```
docker compose up --build
```

---

### 3️⃣ Run Manually

#### Backend

```
dotnet run
```

#### Frontend

```
npm start
```

---

### 4️⃣ Database Migration

```
dotnet ef migrations add Init
dotnet ef database update
```

---

## 🧪 Sample API

### POST /api/signals

```
{
  "componentId": "RDBMS_PRIMARY",
  "payload": "Database timeout"
}
```

---

## 📊 Key Design Decisions

### 🔹 Backpressure Handling

* Used Channel queue to prevent overload
* Worker processes signals asynchronously

### 🔹 Resilience

* Mongo failures do not crash system
* Retry logic implemented

### 🔹 Scalability

* Can replace Channel with Kafka
* Redis can be added for real-time dashboard

---

## 🧪 Testing Strategy

* Unit tests for:

  * RCA validation
  * Debounce logic

---

## 🏁 Future Improvements

* Kafka integration
* WebSocket live dashboard
* Distributed tracing
* Alerting integrations (Email/SMS)

---

## 👨‍💻 Author

Your Name
