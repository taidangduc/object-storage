# Image Gallery
Practical implementation of image post-processing with cloud services integration.

# Architecture

```mermaid
flowchart LR
  X[Browser] --> A[Frontend]
  A --> B[C# API]
  B --> C[Storage]
  B --> D[Messaging]
  B --> E[Database]
  D --> |Event Trigger| F[Background Worker<br/>or Serverless]
  F --> C
  F --> E
```
## Storage Providers

| Storage         | Status         | Path |
|------------------|:------:|------|
| Azure Blob       | <center>✅</center>     | [/Storage/Azure](src/Backend/Infrastructure/Storage/Azure)|
| Fake             | <center>✅</center>     | [/Storage/Fake](src/Backend/Infrastructure/Storage/Fake) |

## Messaging Providers

| Messaging            | Status         | Path           |
|---------------------|:------:|----------------|
| Azure Queue Storage | <center>✅</center>     | [/Messaging/AzureQueueStorage](src/Backend/Infrastructure/Messaging/AzureQueueStorage) |
| Fake                | <center>✅</center>     | [/Messaging/Fake](src/Backend/Infrastructure/Messaging/Fake) |

