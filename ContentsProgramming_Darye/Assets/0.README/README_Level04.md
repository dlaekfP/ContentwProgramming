━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

📖 상황 설명

당신은 빛 밝기 조절 시스템을 만들고 있습니다. 2개의 Button(어두움, 밝음)을 클릭하면 3D Sphere의 색상이 변경되고, TextMeshPro에 현재 상태가 표시되며, 밝음 모드일 때만 추가 정보 패널이 나타나야 합니다.
✅ UI를 구성하는 데 있어 Layout은 상관없음.
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

📦 제공된 프로젝트 상태

✅ 빈 씬 (Scene)
   • Main Camera
   • Directional Light

❌ 미완성
   • Canvas 생성 필요
   • 3D GameObject 생성 필요
   • Button UI 생성 필요
   • Panel 생성 필요
   • 스크립트 작성 필요

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

✨ 세부 요구사항

1️⃣ GameObject 및 Canvas 생성 (0.5점)

   📦 Sphere 생성
      • 이름: LightBulb
      • Position: (0, 0, 0)

   📦 Canvas 생성

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

2️⃣ UI Button, Text, Panel 생성 (1.5점)

   📦 Button 2개 생성
      • 이름: DarkButton, BrightButton
      • 각 버튼 아이콘 변경 (05.Resources/Dark, Shine)

   📦 TextMeshProUGUI 생성
      • 이름: StatusText
      • 초기 텍스트: "밝기: 어두움"

   📦 Panel 생성
      • 이름: InfoPanel
      • Panel 내부에 TextMeshProUGUI 추가 (이름: InfoText)
      • InfoText 내용: "현재 조명이 켜져 있습니다"

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

3️⃣ 스크립트 생성 및 함수 구현 (2점)

   📝 LightController.cs 스크립트 생성
      • LightBulb 
      • StatusText 
      • InfoPanel 

   🔧 2개의 함수 구현
      • SetDark() 함수
        - LightBulb 색상: 회색으로 변경
        - StatusText: "밝기: 어두움"으로 표시
        - InfoPanel: 비활성화

      • SetBright() 함수
        - LightBulb 색상: 하얀색으로 변경
        - StatusText: "밝기: 밝음"으로 표시
        - InfoPanel: 활성화

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

4️⃣ 채점 기준

Play 모드에서 Button을 클릭했을 때:

   ✅ 초기 상태
      • InfoPanel: 보이지 않음 (비활성화)
      • StatusText: "밝기: 어두움"

   ✅ BrightButton 클릭
      • LightBulb 색상: 하얀색
      • StatusText: "밝기: 밝음"
      • InfoPanel: 나타남 (활성화)
      • InfoText: "현재 조명이 켜져 있습니다" 표시

   ✅ DarkButton 클릭
      • LightBulb 색상: 회색
      • StatusText: "밝기: 어두움"
      • InfoPanel: 사라짐 (비활성화)

   ✅ BrightButton → DarkButton → BrightButton 반복 클릭
      • InfoPanel이 토글되듯이 나타났다 사라졌다 반복

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
