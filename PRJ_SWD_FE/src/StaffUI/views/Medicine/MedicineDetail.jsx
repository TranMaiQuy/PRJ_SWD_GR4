import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

const MedicineDetail = () => {
  const { id } = useParams();
  const [medicine, setMedicine] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetch(`https://localhost:7012/api/medicine/detail/${id}`)
      .then((res) => {
        if (!res.ok) throw new Error("Failed to fetch medicine");
        return res.json();
      })
      .then((data) => {
        setMedicine(data);
        setLoading(false);
      })
      .catch((err) => {
        console.error("Fetch error:", err);
        alert("Error loading medicine");
        setLoading(false);
      });
  }, [id]);

  if (loading) return <p>Loading...</p>;
  if (!medicine) return <p>Medicine not found</p>;

  return (
    <div style={{ maxWidth: "800px", margin: "0 auto" }}>
      <h2>Medicine Detail #{medicine.medicineId}</h2>
      <p><strong>Name:</strong> {medicine.name}</p>
      <p><strong>Quantity:</strong> {medicine.quantity}</p>
      <p><strong>Price:</strong> {medicine.price.toLocaleString()} ₫</p>
      <button onClick={() => window.location.href = "/medicine"}>← Back to list</button>
    </div>
  );
};

export default MedicineDetail;
