# TODO

This document keeps track of what must be done and in which order.

- [x] Player click to play-area should count clicks and increment coins;
- [x] Load sample helpers to screen. A helper should display: name, buy price, current quantity, current total production, production per piece. Should behave: it can be bought;
- [x] Implement basic image representation for helpers;
- [ ] Implementar OnUpgrade or OnLevelUp em helpers;
- [ ] Make class HelperManager init the Helpers from a file;
- [ ] Implement basic audio on events (OnItemBought, attack (click), etc);
- [ ] Create basic status to improve resource production by X%.

## Advanced 

- [x] Create a Achievement Manager to handle Achievements;
- [ ] Create a Status Manager to handle different status simultaneously;
- [ ] Create an Audio Manager to handle background music, effects sounds, etc.

## Flow

() = between parentheses is function/action
[] = between bracket is result/event generated
Events are useful to play audio, display animations, etc

### Action / Event name (Sample)

**Action:** Who does what
**Simplified flow:** Actor -> does => result
**In depth Description:**

### Player Clicks on resource Area (Attack Area)

**Action:** Player (clicks) to generate resources:
**Simplified flow:** PlayerClick -> (ProduceResource) => [resourceProduced]
**In depth description:** Player (clicks) on Button 'playAreaButton'. An event handler was attached to it by Idlegfw, it then calls the function responsible for handling the click. The function generates resource to the player. (TODO: and displays a visual indicator that the click occurred.)

### Player buy item

**Action:** Player buy item
**Simplified flow:** Player -> (Buy item) -> (SpendResource) => [OnItemBought/resourceSpent]
**In depth Description:** Player (clicks) on the buy button for a helper/cursor. The helper list was created by the App and has a handler to dispatch a custom OnItemBought event on click.
The OnItemBought is then handled by the Idlegfw that (verifies) if the player has enough resource to buy the helper. If the player has enough then the OnItemBought method is called in the helper.

### Upgrade Helper

**Action:** Player Upgrade Helper
**Simplified flow:** Player -> (Upgrade Helper) -> (SpendResource) => [OnUpgrade||OnLevelUp/resourceSpent]
**In depth Description:**  Jogador seleciona o helper que deseja fazer a melhoria. App tem um manipulador que dispara um evento OnUpgrade/OnLevelUp. OnUpgrade/OnLevelUp é manipulado pelo **Idlegfw** que verifica se o jogador tem recurso suficiente para fazer o upgrade do helper. 
Se o jogador tem recurso, então OnUpgrade/OnLevelUp é chamado no helper.

## Responsibilities 

Idlegfw.cs is responsible for handling events fired by the Game, loading configs and saving/loading the state of the game.

Game.js is responsible for keeping the current status of the player and its resources/helpers.

Player Actions:
Click to generate resources
Buy Resources

###  Status

In short: Status are temporary effects that affect resource generation. A status is a generic and broad concept. It can be anything, really. But a few points must be noted.
Sample Status:
```js
var options = {
    expireTime: 60, // time in seconds
    effectType: positive, // if it will increase or decrease the production
    name: '', // the status name
    effect: 5, // precentual effect on what it will affect
    stack: false, // if the same effect/status can be apllied at the same time.
    affects: production, // default value (and maybe the only one possible)
    description: '',
    visual: '', // image to be displayed
    condition: '', // when to trigger the effect
};
var status = statusManager.createStatus(options);
statusManager.toApplyList.push(status);
```

### Exemplo de Upgrade

Helper Descrição: Ivan, O lutador, productionValue: 100 -> 200 Upgraded
Upgrade Descricao: Copo de Cerveja, Efeito: Aumenta o DPS de Ivan, O lutador em 100%.

Helper Decrição: Alexa, Assassina, productionValue: 200 -> 300 Upgraded (500%)
Upgrade Descricao: Golpe crítico, Efeito: Aumenta sua chande de toque crítico em 50%

Helper Descrição: Rei Midas, productionValue: 500 -> 
Upgrade Descricao: Saco sem fundo, Efeito: Aumenta todo ouro encontrado em 25%.