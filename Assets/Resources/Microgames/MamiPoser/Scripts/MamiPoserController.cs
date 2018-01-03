﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamiPoserController : MonoBehaviour {
    //[Header("The object containing the characters")]
    //public GameObject characterLibrary;

    [Header("Mamizou prefab")]
    public MamiPoserMamizou mamizouPrefab;

    [Header("Other characters prefabs")]
    public MamiPoserCharacter[] characterPrefabs;

    [Header("Number of character copies to be spawned")]
    public int characterSpawnNumber;

    [Header("X coordinate bounds for spawned characters")]
    public float leftBound = -20.0f/3, rightBound = 20.0f/3;

    [Header("Y coordinate for spawned characters")]
    public float yCoordinate = -5f;

    private MamiPoserCharacter chosenCharacterPrefab;
    private int mamizouIndex;
    private List<MamiPoserCharacter> createdCharacters;

    private Vector2 CharacterPosition(int index)
    {
        print("X position for clone number " + index + ": " + (leftBound + (1 + 2 * index) * (rightBound - leftBound) / (2 * characterSpawnNumber)));
        return new Vector2(leftBound + (1 + 2 * index) * (rightBound - leftBound) / (2 * characterSpawnNumber), yCoordinate);
    }

    void Start()
    {
        // Determine which character to use and which of the copies is Mamizou
        chosenCharacterPrefab = characterPrefabs[Random.Range(0, characterPrefabs.Length)];
        print("Chosen character prefab: " + chosenCharacterPrefab);
        mamizouIndex = Random.Range(0, characterSpawnNumber);
        print("Mamizou index: " + mamizouIndex);

        // Spawn the characters
        createdCharacters = new List<MamiPoserCharacter>();
        for (int i = 0; i < characterSpawnNumber; i++)
        {
            MamiPoserCharacter newCharacter = Instantiate(chosenCharacterPrefab, CharacterPosition(i), Quaternion.identity);
            createdCharacters.Add(newCharacter);
            if (i == mamizouIndex)
                newCharacter.SetDisguised();
            else
                newCharacter.SetRegular();
        }
    }
}
