# Multiplayer Camera Controller with Photon PUN

This Unity project demonstrates how to spawn and assign individual cameras to players in a multiplayer environment using Photon PUN. Each player controls their own camera, and movement is handled using standard WASD keys. The camera maintains a consistent height above any plane, and players can jump and crouch.

## Features

- **Per-Player Camera Assignment**: Each player gets a unique camera upon joining the game, which only they can control.
- **Movement Controls**: Use `WASD` for movement, `Space` to jump, and `Left Ctrl` to crouch.
- **Camera Gravity and Height Maintenance**: The camera remains at a fixed height above any plane, simulating a gravity system that keeps the camera from touching the ground.
- **Photon PUN Integration**: Leverages Photon PUN to handle player connections, instantiation, and RPC calls.

## Setup

### Prerequisites

- **Unity**: Make sure you have Unity installed (preferably the latest LTS version).
- **Photon PUN**: Import Photon PUN into your Unity project. You can find it on the Unity Asset Store or through the Photon website.

### Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-username/your-repository-name.git
   ```
   Replace `your-username` and `your-repository-name` with your GitHub username and repository name.

2. **Open the Project in Unity**: Navigate to the project folder and open it with Unity.

3. **Setup Photon PUN**:
   - Create a Photon account if you don't have one.
   - Import Photon PUN into the project.
   - Set up your Photon App ID in the Unity Editor (`Window > Photon Unity Networking > PUN Wizard`).

4. **Assign Prefabs**:
   - Create your player and camera prefabs.
   - Assign these prefabs to the `CameraSpawner` script in the Unity Editor.

### Usage

1. **Player Prefab**: Ensure your player prefab contains the necessary components (e.g., `Rigidbody`, `Collider`, etc.) and is configured for multiplayer.
  
2. **Camera Prefab**: The camera prefab should have the `CameraController` script attached.

3. **Running the Game**: 
   - Run the game in the Unity Editor or build and run it on multiple clients.
   - As each player joins, they will receive their own camera, which they can control.

### Scripts

#### CameraSpawner.cs

This script is responsible for spawning a camera when a player joins the game and assigning that camera to the player.

- **OnPlayerEnteredRoom**: Listens for new players joining and triggers the camera spawn.
- **SpawnCamera**: Instantiates the camera for the player and assigns it using Photon RPC.

#### CameraController.cs

This script handles the camera movement, ensuring that each player can control their own camera using standard input controls.

- **Move()**: Handles WASD movement.
- **HandleJump()**: Enables jumping with the `Space` key.
- **HandleCrouch()**: Allows crouching with the `Left Ctrl` key.
- **MaintainHeight()**: Keeps the camera at a fixed height above any plane.

### Customization

- **Speed, Jump Force, and Crouch Height**: You can adjust the `speed`, `jumpForce`, and `crouchHeight` variables in the `CameraController` script to fine-tune player movement.
- **Camera Height**: Modify the `MaintainHeight()` method to adjust how the camera maintains its position above the ground.

### License

This project is open-source and available under the MIT License. Feel free to modify and distribute it as per the license terms.

---
