using UnityEngine;
using System.Collections;

public class TCPHandshake : MonoBehaviour
{
    public Transform client;     // مكان الكلاينت
    public Transform server;     // مكان السيرفر
    public GameObject synPrefab;     // الكرة بتاعة SYN
    public GameObject synAckPrefab;  // الكرة بتاعة SYN-ACK
    public GameObject ackPrefab;     // الكرة بتاعة ACK

    public float moveSpeed = 2f;      // سرعة حركة الكرات
    public float delayBetweenPackets = 0.5f;  // تأخير بين كل حركة باكت وباكت

    void Start()
    {
        StartCoroutine(HandshakeSequence());
    }

    IEnumerator HandshakeSequence()
    {
        // 1. Send SYN
        yield return SpawnAndMovePacket(synPrefab, client.position, server.position);

        // انتظار بسيط قبل الرد
        yield return new WaitForSeconds(delayBetweenPackets);

        // 2. Send SYN-ACK
        yield return SpawnAndMovePacket(synAckPrefab, server.position, client.position);

        yield return new WaitForSeconds(delayBetweenPackets);

        // 3. Send ACK
        yield return SpawnAndMovePacket(ackPrefab, client.position, server.position);
    }

    IEnumerator SpawnAndMovePacket(GameObject packetPrefab, Vector3 start, Vector3 end)
    {
        // إنشاء الباكت
        GameObject packet = Instantiate(packetPrefab, start, Quaternion.identity);

        // تشغيل الصوت لو موجود
        AudioSource audio = packet.GetComponent<AudioSource>();
        if (audio != null)
            audio.Play();

        // تحريك الباكت
        while (Vector3.Distance(packet.transform.position, end) > 0.05f)
        {
            packet.transform.position = Vector3.MoveTowards(packet.transform.position, end, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // بعد ما يوصل لمكانه خليه يختفي
        Destroy(packet, 1f);
    }
}
