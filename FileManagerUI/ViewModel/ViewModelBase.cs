using GalaSoft.MvvmLight;
using System.ComponentModel;

namespace FileManagerUIWpf.ViewModel {
	public class ViewModelBase : ObservableObject, INotifyPropertyChanged {
		// 属性变更通知方法
		protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null) {
			if (EqualityComparer<T>.Default.Equals(field, value)) return false;
			field = value;
			RaisePropertyChanged(propertyName);
			return true;
		}

		// 显示加载状态
		private bool _isLoading;
		public bool IsLoading {
			get => _isLoading;
			set => Set(ref _isLoading, value);
		}
	}
}