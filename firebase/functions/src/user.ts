
export interface User {
    username: string
    currentLevel: number
    xp: number
    highestWave: number
    unlockedMaps: Record<string, boolean>
}