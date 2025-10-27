━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

📖 상황 설명

당신은 음악 플레이어 UI 시스템을 만들고 있습니다. Toggle로 플레이어를 켜고 끄며, Slider로 볼륨을 조절하고, Button으로 재생/정지를 제어합니다. 볼륨에 따라 Image 아이콘의 색상과 크기가 변경되고, TextMeshPro에 상태가 표시되어야 합니다.
✅ UI를 구성하는 데 있어 Layout은 상관없음.
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

📦 제공된 프로젝트 상태

✅ 이미 제공된 것들
   • Main Camera
   • Directional Light
   • MusicPlayer GameObject (AudioSource 컴포넌트 포함)
     - AudioSource에 음악 파일이 이미 설정됨
     - MusicPlayerController.cs 스크립트가 이미 연결됨
     - PlayMusic(), StopMusic() 함수가 이미 구현되어 있음

❌ 미완성
   • Canvas 생성 필요
   • Toggle, Panel, Slider, Button, Image 생성 필요
   • 스크립트에 추가 함수 구현 필요
   • UI 이벤트 연결 필요

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

✨ 세부 요구사항

1️⃣ Canvas 및 기본 UI 생성 (0.5점)

   📦 Canvas 생성
      • Render Mode: Screen Space - Overlay

   📦 Toggle 생성
      • 이름: PlayerToggle
      • Label 텍스트: "플레이어 켜기"

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

2️⃣ Panel 및 내부 UI 생성 (1점)

   📦 Panel 생성
      • 이름: PlayerPanel

   📦 Panel 내부 구성
      • Slider: VolumeSlider (Min: 0, Max: 10, Value: 5)
        - 이름: VolumeSlider
        - 수치: Min 0, Max 10, Values 5
        
      • TextMeshProUGUI: (초기 텍스트: "볼륨: 5")
        - 이름: VolumeText
        - 텍스트: "볼륨: 5"

      • Button 2개: PlayButton, StopButton
        - 이름: PlayButton, StopButton
        - PlayButton 텍스트: "재생"
        - StopButton 텍스트: "정지"

      • Image: VolumeIcon (볼륨 아이콘 표시용)
        - Image Type: Filled
        - Fill Method: Radial 360
        - Fill Origin: Bottom
        - Fill Amount: 0.5 (초기값 50%)

      • TextMeshProUGUI: StatusText (초기 텍스트: "정지 중")

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

3️⃣ 스크립트 변수 선언 (0.5점)

   📝 MusicPlayerController.cs (이미 생성되어 있음)
      • 이미 구현된 함수: PlayMusic(), StopMusic()

   📝 추가로 선언할 변수들
      • PlayerPanel
      • VolumeSlider
      • VolumeText
      • VolumeIcon
      • StatusText

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

4️⃣ 함수 구현 (1점)

   🔧 OnPlayerToggled(bool isOn) 함수
      • Toggle 상태에 따라 PlayerPanel SetActive 제어

   🔧 OnVolumeChanged(float volume) 함수
      • VolumeText 업데이트: "볼륨: [볼륨 값]"
      • VolumeIcon 색상 변경:
        - 볼륨 0: 회색 (Color.gray)
        - 볼륨 1~50: 노란색 (Color.yellow)
        - 볼륨 51~100: 녹색 (Color.green)
      • VolumeIcon fillAmount 변경:
        - 예: 볼륨 0 → fillAmount 0.0, 볼륨 5 → fillAmount 0.5, 볼륨 10 → fillAmount 1.0

   🔧 OnPlayClicked() 함수
      • StatusText 업데이트: "재생 중"

   🔧 OnStopClicked() 함수
      • StatusText 업데이트: "정지 중"

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

5️⃣ Inspector 연결 (1점)

   🔗 MusicPlayerController.cs, GameObject 참조 연결
   
   🔗 이벤트 연결

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

6️⃣ 채점 기준

Play 모드에서 다음 동작 확인:

   ✅ 초기 상태
      • PlayerToggle: OFF 상태
      • PlayerPanel: 보이지 않음
      • 음악: 재생되지 않음

   ✅ PlayerToggle 클릭 (ON)
      • PlayerPanel 나타남
      • VolumeSlider: 5
      • VolumeText: "볼륨: 5"
      • VolumeIcon: 노란색, fillAmount 0.5 (반원)
      • StatusText: "정지 중"

   ✅ VolumeSlider 조작
      • 0으로 조절 → VolumeText: "볼륨: 0", VolumeIcon: 회색, fillAmount 0.0 (비어있음)
      • 3으로 조절 → VolumeText: "볼륨: 3", VolumeIcon: 노란색, fillAmount 0.3
      • 8으로 조절 → VolumeText: "볼륨: 8", VolumeIcon: 녹색, fillAmount 0.8
      • 10으로 조절 → VolumeText: "볼륨: 10", VolumeIcon: 녹색, fillAmount 1.0 (완전히 채워짐)

   ✅ PlayButton 클릭
      • StatusText: "재생 중"
      • 음악이 실제로 재생됨

   ✅ StopButton 클릭
      • StatusText: "정지 중"
      • 음악이 정지됨

   ✅ PlayerToggle 다시 클릭 (OFF)
      • PlayerPanel 사라짐
      • 음악이 재생 중이었다면 계속 재생 (Panel만 숨김)

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
