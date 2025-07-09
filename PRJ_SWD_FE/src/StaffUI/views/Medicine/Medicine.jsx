import React, { useEffect, useState } from "react";

function Medicine() {
  const [medicines, setMedicines] = useState([]);

  useEffect(() => {
    fetch("https://localhost:7012/api/medicine/list") // URL đến API
      .then((res) => res.json())
      .then((data) => setMedicines(data))
      .catch((err) => console.error("Lỗi khi load medicine:", err));
  }, []);

  return (
    <div className="p-4">
      <h2 className="text-xl font-bold mb-4">Danh sách thuốc</h2>
      <table className="w-full border-collapse border">
        <thead>
          <tr className="bg-gray-200">
            <th className="border p-2">ID</th>
            <th className="border p-2">Tên thuốc</th>
            <th className="border p-2">Số lượng</th>
            <th className="border p-2">Giá</th>
          </tr>
        </thead>
        <tbody>
          {medicines.map((m) => (
            <tr key={m.medicineId}>
              <td className="border p-2">{m.medicineId}</td>
              <td className="border p-2">{m.name}</td>
              <td className="border p-2">{m.quantity}</td>
              <td className="border p-2">{m.price}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default Medicine;
