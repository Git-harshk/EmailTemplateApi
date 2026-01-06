# Email Template API

This project is a simple ASP.NET Core Web API that generates a short email
template based on the provided purpose, recipient name, and tone.
The email content is generated using AI.

---

## API Example

### Endpoint
POST /api/Email

### Request
```json
{
  "purpose": "Apology for delayed delivery",
  "recipientName": "Harsh",
  "tone": "Polite"
}
Response
json
Copy code
{
  "emailBody": "Dear Harsh, We sincerely apologize for the delay...",
  "responseTimeMs": 3044
}
Environment Setup
Clone the repository

Open the project in Visual Studio

Restore NuGet packages

Add your OpenAI API key using environment variables or configuration

Run the project

Open Swagger at:
https://localhost:{port}/swagger

How AI Was Used
The OpenAI API is used to generate a short email template based on the
input parameters. The request includes a controlled prompt to ensure
the response remains professional and concise.

Additional Notes
Response time for AI calls is measured using a simple timestamp difference

Controller and service logic are kept separate

API keys are handled securely and not committed to source control

yaml
Copy code

---
