import React, { useEffect, useState } from "react";

const Prescription = () => {
  const [prescriptions, setPrescriptions] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetch("https://localhost:7012/api/prescription/list")
      .then((res) => {
        if (!res.ok) throw new Error("Không thể tải danh sách toa thuốc");
        return res.json();
      })
      .then((data) => {
        setPrescriptions(data);
        setLoading(false);
      })
      .catch((err) => {
        console.error("Lỗi khi tải:", err);
        setLoading(false);
      });
  }, []);

  const handleCreate = () => {
    window.location.href = "/prescription/create";
  };

  const handleDetail = (id) => {
    window.location.href = `/prescription/detail/${id}`;
  };

  const handleEdit = (id) => {
    window.location.href = `/prescription/edit/${id}`;
  };

  const handleDelete = (id) => {
    if (!window.confirm("Bạn có chắc chắn muốn xoá toa thuốc này?")) return;

    fetch(`https://localhost:7012/api/prescription/${id}`, {
      method: "DELETE",
    })
      .then((res) => {
        if (!res.ok) throw new Error("Xoá toa thuốc thất bại");
        setPrescriptions((prev) => prev.filter((p) => p.prescriptionId !== id));
      })
      .catch((err) => console.error("Lỗi xoá:", err));
  };

  if (loading) return <p>Đang tải danh sách toa thuốc...</p>;

  return (
    <div style={{ padding: "30px", maxWidth: "1000px", margin: "auto" }}>
      <h2 style={{ fontSize: "24px", fontWeight: "bold", marginBottom: "20px" }}>
        Danh sách toa thuốc
      </h2>

      <button
        onClick={handleCreate}
        style={{
          padding: "10px 16px",
          backgroundColor: "#28a745",
          color: "white",
          border: "none",
          borderRadius: "5px",
          marginBottom: "20px",
          cursor: "pointer",
        }}
      >
        + Thêm toa thuốc
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
            <th>Bác sĩ</th>
            <th>Bệnh nhân</th>
            <th>Thuốc</th>
            <th>Liều dùng</th>
            <th>Ghi chú</th>
            <th>Tổng tiền</th>
            <th>Hành động</th>
          </tr>
        </thead>
        <tbody>
          {prescriptions.map((p) => (
            <tr key={p.prescriptionId}>
              <td>{p.prescriptionId}</td>
              <td>{p.doctorName}</td>
              <td>{p.customerName}</td>
              <td>{p.medicineName}</td>
              <td>{p.dosage}</td>
              <td>{p.note}</td>
              <td>{p.totalCost.toLocaleString()} ₫</td>
              <td>
                <button onClick={() => handleDetail(p.prescriptionId)}>Chi tiết</button>{" "}
                <button onClick={() => handleEdit(p.prescriptionId)}>Sửa</button>{" "}
                <button onClick={() => handleDelete(p.prescriptionId)}>Xoá</button>
              </td>
            </tr>
          ))}
          {prescriptions.length === 0 && (
            <tr>
              <td colSpan="8" style={{ textAlign: "center", color: "#888", padding: "12px" }}>
                Không có toa thuốc nào
              </td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
};

export default Prescription;
