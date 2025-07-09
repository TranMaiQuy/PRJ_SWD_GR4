import React, { useEffect, useState } from "react";

const Medicine = () => {
  const [medicines, setMedicines] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetch("https://localhost:7012/api/medicine/list")
      .then((res) => {
        if (!res.ok) throw new Error("Failed to fetch medicines");
        return res.json();
      })
      .then((data) => {
        setMedicines(data);
        setLoading(false);
      })
      .catch((err) => {
        console.error("Fetch error:", err);
        setLoading(false);
      });
  }, []); // ✅ Thêm dependency [] để tránh gọi liên tục

  const handleCreate = () => {
    window.location.href = "/medicine/create";
  };

  const handleEdit = (id) => {
    window.location.href = `/medicine/edit/${id}`;
  };

  const handleDetail = (id) => {
    window.location.href = `/medicine/detail/${id}`;
  };

  const handleDelete = (id) => {
    if (!window.confirm("Bạn có chắc chắn muốn xoá thuốc này?")) return;

    fetch(`https://localhost:7012/api/medicine/${id}`, {
      method: "DELETE",
    })
      .then((res) => {
        if (!res.ok) throw new Error("Failed to delete medicine");
        setMedicines((prev) => prev.filter((m) => m.medicineId !== id));
      })
      .catch((err) => console.error("Delete error:", err));
  };

  if (loading) return <p>Đang tải dữ liệu thuốc...</p>;

  return (
    <div style={{ padding: "30px", maxWidth: "1000px", margin: "auto" }}>
      <h2 style={{ fontSize: "24px", fontWeight: "bold", marginBottom: "20px" }}>
        Danh sách thuốc
      </h2>
      <button
        onClick={handleCreate}
        style={{
          padding: "10px 16px",
          backgroundColor: "green",
          color: "white",
          border: "none",
          borderRadius: "5px",
          marginBottom: "20px",
          cursor: "pointer",
        }}
      >
        + Thêm thuốc
      </button>
      <table
        border="1"
        cellPadding="8"
        style={{
          borderCollapse: "collapse",
          width: "100%",
          textAlign: "left",
        }}
      >
        <thead style={{ backgroundColor: "#e0f7e9" }}>
          <tr>
            <th>ID</th>
            <th>Tên thuốc</th>
            <th>Số lượng</th>
            <th>Giá</th>
            <th>Hành động</th>
          </tr>
        </thead>
        <tbody>
          {medicines.map((m) => (
            <tr key={m.medicineId}>
              <td>{m.medicineId}</td>
              <td>{m.name}</td>
              <td>{m.quantity}</td>
              <td>{m.price.toLocaleString()} ₫</td>
              <td>
                <button onClick={() => handleDetail(m.medicineId)}>Chi tiết</button>{" "}
                <button onClick={() => handleEdit(m.medicineId)}>Sửa</button>{" "}
                <button onClick={() => handleDelete(m.medicineId)}>Xoá</button>
              </td>
            </tr>
          ))}
          {medicines.length === 0 && (
            <tr>
              <td colSpan="5" style={{ textAlign: "center", padding: "12px", color: "#888" }}>
                Không có dữ liệu
              </td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
};

export default Medicine;
