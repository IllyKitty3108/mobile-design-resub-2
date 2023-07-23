using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle : MonoBehaviour
{
    // Define an array to store the correct rotations of the puzzle pieces.
    private Quaternion[] correctRotations;

    private void Start()
    {
        Shuffle();

        // Initialize the array with the correct rotations of the puzzle pieces.
        correctRotations = new Quaternion[16];
        for (int i = 0; i < 16; i++)
        {
            GameObject pieceObject = GameObject.Find((i + 1).ToString());
            if (pieceObject != null)
            {
                correctRotations[i] = pieceObject.transform.localRotation;
            }
            else
            {
                Debug.LogError("Puzzle piece with name " + (i + 1).ToString() + " not found!");
            }
        }
    }

    private void OnMouseDown()
    {
        Rotate();
        if (IsPuzzleSolved())
        {
            Debug.Log("Congratulations! Puzzle Solved!");
        }
    }

    private void Shuffle()
    {
        float randomAngle = 90 * Random.Range(1, 4);
        transform.Rotate(new Vector3(0f, 0f, randomAngle));
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(0f, 0f, -90f));
    }

   private bool IsApproximatelyEqual(Quaternion a, Quaternion b, float threshold)
{
    return Quaternion.Angle(a, b) < threshold;
}

private bool IsPuzzleSolved()
{
    // Check if each piece's current rotation matches the correct rotation.
    for (int i = 0; i < 16; i++)
    {
        GameObject pieceObject = GameObject.Find((i + 1).ToString());
        if (pieceObject != null)
        {
            Transform piece = pieceObject.transform;
            if (!IsApproximatelyEqual(piece.localRotation, correctRotations[i], 1f))
            {
                return false; // Puzzle is not solved yet.
            }
        }
        else
        {
            Debug.LogError("Puzzle piece with name " + (i + 1).ToString() + " not found!");
            return false;
        }
    }
    return true; // All pieces are in their correct rotations, puzzle is solved.
}


}

