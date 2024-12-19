# 콘솔 2048.cs
![ezgif-4-dfd18f8ed3](https://github.com/user-attachments/assets/e2cd40d7-81e9-4680-b3fa-b649a1f4179b)

C# 콘솔 애플리케이션으로 구현된 간단한 2048 게임입니다.

## 주요 기능

- **클래식 2048 메커니즘**: 동일한 숫자의 타일을 합쳐 2048을 만드세요.
- **직관적인 컨트롤**: 방향키를 사용해 타일을 상하좌우로 이동할 수 있습니다.
- **점수 추적**: 게임 진행 중 점수를 기록합니다.
- **텍스트 기반 인터페이스**: 가벼운 실행 환경으로 콘솔에서 쉽게 실행 가능합니다.
- **힌트 기능**: 최적의 점수를 제안하는 힌트를 제공합니다.

## 설치 방법

1. 레포지토리를 클론합니다:
    
    ```bash
    git clone https://github.com/Leusin/game-2048-dot-cs.git
    ```
    
2. 선호하는 C# IDE(예: Visual Studio 또는 JetBrains Rider)로 프로젝트를 엽니다.
3. 빌드 후 실행합니다.

## 게임 방법

1. 실행 파일을 실행하여 게임을 시작합니다.
2. 방향키를 사용하여 타일을 이동합니다:
    - **`↑`**: 타일을 위로 이동
    - **`↓`**: 타일을 아래로 이동
    - **`←`**: 타일을 왼쪽으로 이동
    - **`→`**: 타일을 오른쪽으로 이동
3. 동일한 숫자의 타일을 합쳐 더 큰 숫자의 타일로 만듭니다.
4. 이동 가능한 타일이 없으면 게임이 종료됩니다.
5. 최대한 높은 숫자를 만들어 기록을 갱신하세요!

## 프로젝트 구조

- **`Program.cs`**: 게임의 엔트리 포인트.
- **`Game.cs`**: 게임의 전체 흐름을 관리하는 로직.
- **`Board.cs`**: 게임 보드의 상태 및 동작(타일 이동/합치기)을 관리.
- **`UI.cs`**: 콘솔에 그려질 텍스트들이 정의되어 있습니다.
- **`Beep.cs`**: 게임 중 간단한 사운드 효과.
- **`KeyControl.cs`**: 입력을 처리.
- **`ScoreSaveLoader.cs`**: 점수 저장 및 로드 기능을 구현.

---

# Console 2048.cs

A simple 2048 game implemented as a C# console application.

## Features
Classic 2048 Mechanics: Combine tiles with the same number to create higher numbers and aim for 2048.
Intuitive Controls: Use arrow keys to move tiles up, down, left, or right.
Score Tracking: Keep track of your score as you play.
Text-Based Interface: Lightweight and easy to run directly in the console.
Hint System: Get suggestions for the best possible move to improve your score.
Installation
1. Clone the repository:
    ```bash
    git clone https://github.com/Leusin/game-2048-dot-cs.git
    ``` 

2. Open the project with your favourite C# IDE (for example, Visual Studio or JetBrains Rider).
3. Build and run the project.

## How to Play
1. Run the executable file to start the game.
2. Use the arrow keys to move the tiles:
 - **`↑`**: Move tiles up
 - **`↓`**: Move tiles down
 - **`←`**: Move tiles left
 - **`→`**: Move tiles right
3. Combine tiles with the same number to form larger tiles.
4. The game ends when no moves are possible.
5. Try to create the largest number possible and beat your high score!

## Project Structure
- **`Program.cs`**: Entry point of the game.
- **`Game.cs`**: Handles the overall game flow and logic.
- **`Board.cs`**: Manages the state of the game board and tile movements.
- **`UI.cs`**: Handles the text-based interface, including drawing the game board and messages to the console.
- **`Beep.cs`**: Provides simple sound effects during gameplay.
- **`KeyControl.cs`**: Handles user input via the arrow keys.
- **`ScoreSaveLoader.cs`**: Implements score saving and loading functionality.
