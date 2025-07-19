import React, { useState } from 'react';
import './CreateBlog.css'; // CSS riêng

function CreateBlog() {
  const [formData, setFormData] = useState({
    title: '',
    content: '',
    description: '',
    personId: '',
    categoryId: '',
    imageFile: null
  });

  const [imagePreview, setImagePreview] = useState(null);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: value
    }));
  };

  const handleImageChange = (e) => {
    const file = e.target.files[0];
    if (file) {
      setFormData(prev => ({
        ...prev,
        imageFile: file
      }));
      setImagePreview(URL.createObjectURL(file));
    }
  };

 const handleSubmit = async (e) => {
  e.preventDefault();

  // Validate ảnh trước khi gửi
  const file = formData.imageFile;
  const validTypes = ['image/jpeg', 'image/png', 'image/jpg', 'image/gif'];
  const maxSizeInMB = 5;

  if (!file) {
    alert("Vui lòng chọn một ảnh.");
    return;
  }

  if (!validTypes.includes(file.type)) {
    alert("File ảnh không hợp lệ. Chỉ chấp nhận JPEG, PNG, JPG, GIF.");
    return;
  }

  if (file.size > maxSizeInMB * 1024 * 1024) {
    alert(`Kích thước ảnh vượt quá ${maxSizeInMB}MB`);
    return;
  }
  if (Number(formData.personId) <= 0) {
    alert("Person ID phải lớn hơn 0.");
    return;
  }

  if (Number(formData.categoryId) <= 0) {
    alert("Category ID phải lớn hơn 0.");
    return;
  }


  const formDataToSend = new FormData();
  formDataToSend.append("title", formData.title);
  formDataToSend.append("description", formData.description);
  formDataToSend.append("content", formData.content);
  formDataToSend.append("personId", formData.personId);
  formDataToSend.append("categoryId", formData.categoryId);
  formDataToSend.append("image", file);

  try {
    const response = await fetch("https://localhost:7012/api/blog/create", {
      method: "POST",
      body: formDataToSend
    });

    if (!response.ok) throw new Error("Tạo blog thất bại");

    await response.json();
    alert("Tạo blog thành công!");
  } catch (error) {
    console.error("Lỗi tạo blog:", error);
    alert("Có lỗi xảy ra khi tạo blog.");
  }
};


  return (
    <div className="form-container">
      <h2 className="form-title">Create New Blog</h2>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label>Title</label>
          <input name="title" value={formData.title} onChange={handleChange} required />
        </div>

        <div className="form-group">
          <label>Description</label>
          <textarea name="description" value={formData.description} onChange={handleChange} required />
        </div>

        <div className="form-group">
          <label>Content</label>
          <textarea name="content" value={formData.content} onChange={handleChange} required />
        </div>

        <div className="form-group">
          <label>Upload Image</label>
          <input type="file" accept="image/*" onChange={handleImageChange} />
          {imagePreview && (
            <img src={imagePreview} alt="Preview" className="image-preview" />
          )}
        </div>

        <div className="form-group">
          <label>Person ID</label>
          <input type="number" name="personId" value={formData.personId} onChange={handleChange} required />
        </div>

        <div className="form-group">
          <label>Category ID</label>
          <input type="number" name="categoryId" value={formData.categoryId} onChange={handleChange} required />
        </div>

        <button type="submit" className="submit-btn">Create Blog</button>
      </form>
    </div>
  );
}

export default CreateBlog;
