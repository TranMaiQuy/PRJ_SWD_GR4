import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

const PrescriptionDetail = () => {
  const { id } = useParams();
  const [prescription, setPrescription] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetch(`https://localhost:7012/api/prescription/detail/${id}`)
      .then((res) => {
        if (!res.ok) throw new Error("Failed to fetch prescription");
        return res.json();
      })
      .then((data) => {
        setPrescription(data);
        setLoading(false);
      })
      .catch((err) => {
        console.error("Fetch error:", err);
        alert("Error loading prescription");
        setLoading(false);
      });
  }, [id]);

  if (loading) return <p>Loading...</p>;
  if (!prescription) return <p>Prescription not found</p>;

  return (
    <div style={{ maxWidth: "800px", margin: "0 auto" }}>
      <h2>Prescription Detail #{prescription.prescriptionId}</h2>
      <p><strong>Doctor:</strong> {prescription.doctorName}</p>
      <p><strong>Customer:</strong> {prescription.customerName}</p>
      <p><strong>Medicine:</strong> {prescription.medicineName}</p>
      <p><strong>Dosage:</strong> {prescription.dosage}</p>
      <p><strong>Note:</strong> {prescription.note}</p>
      <p><strong>Total Cost:</strong> ${prescription.totalCost.toFixed(2)}</p>
      <button onClick={() => window.location.href = "/prescription"}>← Back to list</button>
    </div>
  );
};

export default PrescriptionDetail;
