# Onyx VAT Verifier Web (Frontend)

## Overview
Onyx VAT Verifier is a Blazor Web application designed to allow users to verify the validity of VAT IDs. It integrates with a backend API that performs the verification and displays the result to the user.

This project focuses on the frontend portion, built using Blazor WebAssembly with .NET 8.

## Prerequisites
Before running the application, make sure you have the following installed:

- .NET 8 SDK or higher
- Visual Studio or any compatible IDE for Blazor development

## Project Structure
The frontend consists of the following components:
- **Pages**: Contains the main user interface for interacting with the VAT verification service.
- **Services**: Handles communication with the backend API for VAT ID validation.
- **Models**: Defines the data structures for VAT verification requests and responses.

### Main Files:
1. **Pages/Home.razor** - The main page where the user interacts with the app.
2. **Services/VatVerificationService.cs** - A service to send VAT ID verification requests to the backend API.
3. **Models/VerificationResponse.cs** - Contains the structure for the response from the VAT verification API.

