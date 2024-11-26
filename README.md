# Counter Task

## Project Overview
This is a quick and simple app that showcases my abilities with C#, .NET Core & Session Management. The app consists of a single page with 3 main buttons that allow interaction with numbers stored in the session state.

### Requirements:
- Clear Numbers button: Clears all the numbers stored in the session and updates the client-side list of numbers and the count.
- Add Number button: Adds a random number between 1 and 1000 to the session state and updates the client-side list.
- Sum Numbers button: Sums the numbers stored in the session and updates the client-side list in real time.
- Display Numbers: Displays all numbers currently stored in the session, updating the client-side list in real-time.

### Key Features:
- Session-based Persistence: The list of numbers is stored in the session state, so the data persists across multiple tabs in the same browser window but will be cleared once the browser is closed.
- Real-Time Updates: The list of numbers and the count are updated on the client side every time a number is added or cleared, ensuring immediate feedback for the user.

### Technologies Used:
C#, .NET Core, Git, JavaScript

### How It Works:
- When the page is loaded, the app checks the session state for any stored numbers. If they exist, it displays them on the page.
- When the Add Number button is clicked, a random number between 1 and 1000 is generated and added to the session state, with the updated list displayed on the page.
- Clicking Clear Numbers clears the session storage and the displayed numbers.
The numbers persist across multiple tabs (but not after the browser is closed), ensuring the session data is kept consistent while the app is active.
