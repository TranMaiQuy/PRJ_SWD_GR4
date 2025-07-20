import React, { useState } from "react";

const PrescriptionCreate = () => {
  const [form, setForm] = useState({
    examinationId: 0,
    doctorId: 0,
    customerId: 0,
    medicineId: 0,
    dosage: "",
    note: "",
    totalCost: 0,
  });

  const handleChange = (e) => {
    const { name, value } = e.target;

    setForm({
      ...form,
      [name]:
        name === "examinationId" ||
        name === "doctorId" ||
        name === "customerId" ||
        name === "medicineId" ||
        name === "totalCost"
          ? Number(value)
          : value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
 console.log("📦 Dữ liệu gửi lên:", form);
    // Kiểm tra dữ liệu đơn giản
    if (
      form.examinationId <= 0 ||
      form.doctorId <= 0 ||
      form.customerId <= 0 ||
      form.medicineId <= 0 ||
      form.totalCost <= 0
    ) {
      alert("Vui lòng nhập đầy đủ và đúng các trường số.");
      return;
    }

    fetch("https://localhost:7012/api/prescription/create", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(form),
    })
      .then((res) => {
        if (!res.ok) throw new Error("Không thể tạo toa thuốc");
        alert("Tạo toa thuốc thành công!");
        window.location.href = "/prescription";
      })
      .catch((err) => {
        console.error("Lỗi khi tạo toa thuốc:", err);
        alert("Lỗi khi thêm toa thuốc");
      });
  };

  return (
    <div style={{ maxWidth: "600px", margin: "0 auto", padding: "20px" }}>
      <h2>Thêm toa thuốc mới</h2>
      <form onSubmit={handleSubmit}>
        <label>ID khám bệnh (ExaminationId):</label><br />
        <input
          type="number"
          name="examinationId"
          value={form.examinationId}
          onChange={handleChange}
          required
        /><br /><br />

        <label>ID bác sĩ:</label><br />
        <input
          type="number"
          name="doctorId"
          value={form.doctorId}
          onChange={handleChange}
          required
        /><br /><br />

        <label>ID bệnh nhân:</label><br />
        <input
          type="number"
          name="customerId"
          value={form.customerId}
          onChange={handleChange}
          required
        /><br /><br />

        <label>ID thuốc:</label><br />
        <input
          type="number"
          name="medicineId"
          value={form.medicineId}
          onChange={handleChange}
          required
        /><br /><br />

        <label>Liều dùng:</label><br />
        <input
          type="text"
          name="dosage"
          value={form.dosage}
          onChange={handleChange}
          required
        /><br /><br />

        <label>Ghi chú:</label><br />
        <textarea
          name="note"
          value={form.note}
          onChange={handleChange}
          required
        ></textarea><br /><br />

        <label>Tổng chi phí:</label><br />
        <input
          type="number"
          name="totalCost"
          value={form.totalCost}
          onChange={handleChange}
          required
        /><br /><br />

        <button type="submit">Tạo toa thuốc</button>{" "}
        <button type="button" onClick={() => window.location.href = "/prescription"}>Huỷ</button>
      </form>
    </div>
  );
};

export default PrescriptionCreate;
