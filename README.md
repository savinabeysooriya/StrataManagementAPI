# Strata Management API

## Overview

This is the backend service for the Strata Management Portal, built using .NET Core. It provides authentication, authorization, and RESTful APIs for managing buildings, owners, tenants, and maintenance requests.

## Features
- JWT-based authentication & authorization
- Role-based access: 
  - **Admin**: Manages buildings, owners, tenants, and maintenance requests
  - **Owner/Tenant**: Can view and create maintenance requests for their assigned building
- RESTful API design following best practices
- Uses a JSON file as a simulated database
- Implements Repository & Service layers for better maintainability
- Swagger API documentation

## Tech Stack
- **.NET Core** (Backend Framework)
- **JWT Authentication** (Security)
- **Swagger** (API Documentation)
- **Nunit** (Unit Testing)

Runs the app in the development mode.\
Open Swagger [https://localhost:44328/swagger/index.html](https://localhost:44328/swagger/index.html) to view it in the browser.
